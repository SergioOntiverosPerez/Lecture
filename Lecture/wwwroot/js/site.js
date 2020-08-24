const uri = window.location.origin + "/api/professors/";
let professors = [];

function getProfessors() {
    fetch(uri)
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
        let textNode2 = document.createTextNode(professor.surname);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(professor.email);
        td3.appendChild(textNode3);

    });
    professors = data;
}