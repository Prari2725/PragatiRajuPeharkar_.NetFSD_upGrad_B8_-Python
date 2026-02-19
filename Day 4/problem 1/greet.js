let sumbit=document.getElementById("submit")
sumbit.addEventListener("click",function(){
    let name=document.getElementById("text").value
    let message=document.getElementById("message")
    message.textContent=`hello ${name}`
})