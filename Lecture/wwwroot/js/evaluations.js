const uriEvaluations = window.location.origin + "/api/evaluations";

let evaluations = [];

function getEvaluations() {
    fetch(uriEvaluations)
        .then(response => response.json())
        .then(data => _displayEvaluations(data))
        .catch(error => console.error("Unable to get the Evaluations", error));
}

function deleteEvaluation(id) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this evaluation file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                fetch(`${uriEvaluations}/${id}`,
                    {
                        method: 'DELETE'
                    })
                    .then(() => getEvaluations())
                    .catch(error => console.error('Unable to delete the evaluation', error));

                swal("Poof! Your student file has been deleted!", {
                    icon: "success",
                });

            } else {
                swal("The evaluation file is safe");
            }
        });
}


function _displayCount(evalCount) {
    const name = (evalCount === 1) ? "Evaluation" : "Evaluations";
    document.getElementById("counter").innerText = `${evalCount} ${name}`;
}

function _displayEvaluations(data) {
    const tBody = document.getElementById("evaluations");
    tBody.innerHTML = '';

    _displayCount(data.length);


    const button = document.createElement('button');
    const a = document.createElement('a');

    data.forEach(evaluation => {

        let editbutton = a.cloneNode(false);
        editbutton.innerText = 'Edit';
        editbutton.classList.add('btn');
        editbutton.classList.add('btn-secondary');
        let urlEdit = window.location.origin + "/evaluations/edit/" + evaluation.id;
        editbutton.setAttribute('href', urlEdit);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteEvaluation(${evaluation.id})`);
        deleteButton.classList.add('btn');
        deleteButton.classList.add('btn-danger');

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode1 = document.createTextNode(evaluation.student.studentName);
        td1.appendChild(textNode1);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(evaluation.name);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(evaluation.score);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(evaluation.group.name);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        td5.appendChild(editbutton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);

    });

    evaluations = data;
    
}