
async function getData (){
  const getData = await fetch("chartData.php");
  const data = await getData.json();

  return data
}

async function createChar(){

  let data = await getData(); //Obtiene los datos
  
  let labels = data.labels;

  let dataSales = {
    label: "Ventas por producto",
    data: data.dataChar,
    backgroundColor: "rgba(54, 162, 235, 0.2)", 
    borderColor: "rgba(54, 162, 235, 1)",
    borderWidth: 1, 
  };  

  let ctx = document.querySelector("#chartjs_bar_exm") //Se selecciona el canvas del documento
  new Chart(ctx, {
    type: "bar",
    data: {
      labels: labels,
      datasets: [dataSales],
    },
    options: {
      scales: {
        yAxes: [{}],
      },
      legend: {
        display: true,
        position: "bottom",

        labels: {
          fontColor: "#71748d",
          fontFamily: "Circular Std Book",
          fontSize: 14,
        },
      },

      scales: {
        xAxes: [
          {
            ticks: {
              fontSize: 14,
              fontFamily: "Circular Std Book",
              fontColor: "#71748d",
            },
          },
        ],
        yAxes: [
          {
            ticks: {
              fontSize: 14,
              fontFamily: "Circular Std Book",
              fontColor: "#71748d",
            },
          },
        ],
      },
    },
  })
}

window.onload = createChar()