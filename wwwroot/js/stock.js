let resetBtn=document.querySelector('#resetBtn')
function reset(){
  let inputs=document.querySelectorAll('.input-text')
  inputs.forEach(item=>item.value="")
}