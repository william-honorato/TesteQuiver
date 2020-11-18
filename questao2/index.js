function CalcularNumerosDeCedulas(valor){
    const cedulas = [50, 20, 10, 5, 2, 1];
    let totalDeCedulas = 0;
    cedulas.forEach(cedula => {
        let quantidadeDeCedulas = Math.trunc(valor / cedula);
        if(quantidadeDeCedulas > 0){
            console.log(`Nota de ${cedula} quantidade ${quantidadeDeCedulas}`);
            valor -= (cedula * quantidadeDeCedulas);
            totalDeCedulas += quantidadeDeCedulas;
        }
    });
    console.log(`Total de notas: ${totalDeCedulas}`);
}