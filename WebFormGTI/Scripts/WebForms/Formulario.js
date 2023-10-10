function openModal(btn) {
    debugger
    var row = btn.parentNode.parentNode;
    var cells = row.getElementsByTagName("td");
    document.getElementById("editItemID").value = cells[0].innerText;
    document.getElementById("modalName").value = cells[1].innerText;
    document.getElementById("modalEmail").value = cells[2].innerText;
    document.getElementById("modalCPFCNPJ").value = cells[3].innerText;
    document.getElementById("myModal").style.display = "block";
}