const uriProfessors = window.location.origin + "/api/professors/";
const uriStudents = window.location.origin + "/api/students";
let professors = [];
let students = [];

// Professors
function getProfessors() {
    fetch(uriProfessors)
        .then(response => response.json())
        .then(data => _displayProfessors(data))
        .catch(error => console.error('Unable to get the Professors', error));
}

function _displayCount(profeCount) {
    const name = (profeCount === 1) ? 'Professor' : 'Professors';
    document.getElementById("counter").innerText = `${profeCount} ${name}`;
}

function _displayProfessors(data) {
    const tBody = document.getElementById("professors");
    tBody.innerHTML = '';

    _displayCount(data.length);

    data.forEach(professor => {
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(professor.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(professor.email);
        td2.appendChild(textNode2);

    });
    professors = data;
}

// students

function getStudents() {
    fetch(uriStudents)
        .then(response => response.json())
        .then(data => _displayStudents(data))
        .catch(error => console.error('Unable to get students', error));
}

function deleteStudent(id) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this student file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
    .then((willDelete) => {
        if (willDelete) {

            fetch(`${uriStudents}/${id}`,
                { 
                    method: 'DELETE'
                })
                .then(() => getStudents())
                .catch(error => console.error('Unable to delete student', error));

            swal("Poof! Your student file has been deleted!", {
                icon: "success",
                });
        }else {
            swal("Your student file is safe!");
        }
    });
}

function _displayStudentsCount(studentsCount) {
    const name = (studentsCount == 1) ? 'Student' : 'Students';
    document.getElementById("counter").innerHTML = `${studentsCount} ${name}`;
}

function _displayStudents(data) {
    const tBody = document.getElementById("students");
    tBody.innerHTML = "";

    _displayStudentsCount(data.length);

    const button = document.createElement('button');
    const a = document.createElement('a');

    data.forEach(student => {

        let editButton = a.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.classList.add('btn');
        editButton.classList.add('btn-secondary');
        let urlParam = window.location.origin + "/students/edit/" + student.id;
        editButton.setAttribute('href', urlParam);


        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteStudent(${student.id})`);
        deleteButton.classList.add('btn');
        deleteButton.classList.add('btn-danger');


        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode1 = document.createTextNode(student.studentCode);
        td1.appendChild(textNode1);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(student.studentName);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(student.email);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(student.course.name);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });
    students = data;
}
function SearchStudent() {
    var input, filter, table, tr, td, i, textValue;
    var cont = 0;
    input = document.getElementById("search");
    filter = input.value.toUpperCase();
    table = document.getElementById("studentsTable");
    tr = table.getElementsByTagName("tr");       

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        
        if (td) {

            textValue = td.textContent || td.innerText
            
            if (textValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
                cont = cont + 1;
                 _displayStudentsCount(cont)
            } else {
                tr[i].style.display = "none";
                _displayStudentsCount(cont)
            }
        }
    }
}

function NewStudent(){
    const a = document.getElementById("newStudent");
    const urlNewStudent = window.location.origin + "/students/new";
    a.setAttribute('href', urlNewStudent);
}