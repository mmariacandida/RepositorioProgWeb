function handleFileSelect(event) {
    const file = event.target.files[0];
    const uploadIcon = document.querySelector('.upload-icon');
  
    if (file) {
      uploadIcon.style.backgroundImage = `url(${URL.createObjectURL(file)})`;
      uploadIcon.style.backgroundColor = 'transparent';
    } else {
      uploadIcon.style.backgroundImage = '';
      uploadIcon.style.backgroundColor = '#333';
    }
}

function exibirMensagem() {
    alert("Funcionário cadastrado com sucesso!");
}




