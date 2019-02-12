
let datospersonales = document.getElementById('datospersonales');
let datosacademicos = document.getElementById('datosacademicos');
let datospadres = document.getElementById('datospadres');
let datosdocumentos = document.getElementById('datosdocumentos');

datosacademicos.style.display = 'none'; 
datospadres.style.display = 'none';
datosdocumentos.style.display = 'none';

let btn1= document.getElementById('btnsiguiente2').addEventListener('click', pasar);
let btn2= document.getElementById('btnsiguiente3').addEventListener('click', pasar3);
let btn3 = document.getElementById('btnsiguiente4').addEventListener('click', pasar4);
let btn4 =document.getElementById('btnsiguiente5').addEventListener('click', pasar5);

function pasar() {


    if (confirm("Al precionar Aceptar ya no podras volver atras, seguro que deseas continuar?") === true) {

        datospersonales.style.display = 'none';
        datosacademicos.style.display = 'block';

    }
    
}

function pasar3() {

    if (confirm("Al precionar Aceptar ya no podras volver atras, seguro que deseas continuar?") === true) {

       
        datosacademicos.style.display = 'none';
        datospadres.style.display = 'block';

    }


}

function pasar4() {

    if (confirm("Al precionar Aceptar ya no podras volver atras, seguro que deseas continuar?") === true) {


        datospadres.style.display = 'none';
        datosdocumentos.style.display = 'block';
    }

}

function pasar5() {

    

    datospersonales.style.display = 'block';
    datosacademicos.style.display = 'block';
    datospadres.style.display = 'block';
    datosdocumentos.style.display = 'block';

    
    



}
