
const botonesBusqueda = document.querySelectorAll('.boton-busqueda');
const barrasBusqueda = document.querySelectorAll('.barra-busqueda');
const detallesSeries = document.querySelectorAll('.detalles__serie');
const botonSerie = document.querySelectorAll('.boton__serie1')
const series = document.querySelectorAll('.serie');

botonesBusqueda.forEach(boton => {
    boton.addEventListener('click', () => {
        boton.classList.add('none');
        console.log('pulsa');
        const barrabusqueda = boton.nextElementSibling;
        barrabusqueda.classList.remove('none');
    });
});



series.forEach(serie => {
    serie.addEventListener('mouseenter', () => {
       
        const detalleSerie = serie.querySelector('.detalles__serie');
        detalleSerie.classList.remove('none');
    });

    serie.addEventListener('mouseleave', () => {
     
        const detalleSerie = serie.querySelector('.detalles__serie');
        detalleSerie.classList.add('none');
    });
});


