window.onload = function(evet){

    let selectProducts = document.querySelector('#productos')

    let table = document.querySelector('.tbody')
    let formSale = document.querySelector('.formSale')

    let inputCobro = document.querySelector('#inputCobro')
    let buttonCobro = document.querySelector('#btnCobro')

    let spanTotal = document.querySelector('#spanTotal')
    let spanCambio = document.querySelector('#spanCambio')

    let buttonsAdd
    let buttonsLess 

    let buttonsDelete

    //Plantilla para agregar las filas a la tabla de productos
    let templateRow = (product) => {
        return `
            <tr id='tr-producto-${product.value}'>
                <td>${product.innerHTML}</td>
                <td>${product.getAttribute('data-price')}</td>
                <td>
                    <a  data-id='${product.value}' data class="btn btn-rounded btn-light less">-</a>
                    <span id="quantity-${product.value}">1</span>
                    <a  data-id='${product.value}' class="btn btn-rounded btn-light add">+</a>
                </td>
                <td>
                    <a data-id='${product.value}' class="btn  btn-rounded btn-light delete"><i class=" fas fa-window-close"></i></a>
                </td>
            </tr>
        `
    }

    //Plantilla para agregar los inputs con los datos del producto seleccionado
    let templateInputProducto = (product) => {
        return `
            <input type="hidden" id="idProducto-${product.value}" 
                name="productos[${product.value}][idProducto]" 
                value="${product.value}">

            <input type="hidden" id="nombreProducto-${product.value}" 
                name="productos[${product.value}][nombreProducto]" 
                value="${product.innerHTML}">

            <input type="hidden" id="precioProducto-${product.value}" 
                name="productos[${product.value}][precio]" 
                value="${product.getAttribute('data-price')}">

            <input type="hidden" id="cantidadProducto-${product.value}" 
                name="productos[${product.value}][cantidad]" 
                value='1'>
        `
    }

    //Actualiza el total de la venta cuando se agrega un nuevo producto
    let setTotal = (product) =>{
        let total = parseFloat(spanTotal.innerHTML)
        total += parseFloat(product.getAttribute('data-price'))
        spanTotal.innerHTML = total
    }

    //Actualiza el total después de quitar un elemento de la tabla
    let updateTotalAfterDelete = (id)=>{
        let total = parseFloat(spanTotal.innerHTML)
        let product = document.querySelector(`#producto-${id}`)
        let spanQuantity = parseInt(document.querySelector(`#quantity-${id}`).innerHTML)
        let priceProduct = parseFloat(product.getAttribute('data-price')) 
        total -= (priceProduct * spanQuantity)
        spanTotal.innerHTML = total
    }

    //Actualiza el total después de aumentar la cantidad de un producto
    let updateTotalAfterAddProduct = (id)=>{
        let total = parseFloat(spanTotal.innerHTML)
        let product = document.querySelector(`#producto-${id}`)
        let priceProduct = parseFloat(product.getAttribute('data-price')) 

        total += priceProduct 

        spanTotal.innerHTML = total
    }

    //Actualiza el total después de disminuir la cantidad de un producto
    let updateTotalAfterLessProduct = (id)=>{
        let total = parseFloat(spanTotal.innerHTML)
        let product = document.querySelector(`#producto-${id}`)
        let priceProduct = parseFloat(product.getAttribute('data-price')) 

        total -= priceProduct
        spanTotal.innerHTML = total
    }

    //Muestra texto con el cambio a dar cuando se ingresa la cantidad del pago
    let setCambio = () =>{
        let currentValue = parseFloat(inputCobro.value)
        let totalDeCompra = parseFloat(spanTotal.innerHTML)
        let cambio = currentValue - totalDeCompra 
        spanCambio.innerHTML = cambio
    }

    //Actualiza la lista de botones de agregar, disminuir, quitar, 
    //cuando se agrega un nuevo producto a la tabla de productos
    let refreshListButton =() =>{
        //Se obtiene todos los botones de agregar y quitar de la pagina
        buttonsAdd = document.querySelectorAll('.add')
        buttonsLess = document.querySelectorAll('.less')
        buttonsDelete = document.querySelectorAll('.delete')
    } 

    //Actualiza el texto de la cantidad de productos
    function addQuantity(e){
        e.preventDefault

        let idProduct = e.currentTarget.getAttribute('data-id')
        let spanQuantity = document.querySelector(`#quantity-${idProduct}`)
        let op = parseInt(spanQuantity.innerHTML) + 1
        spanQuantity.innerHTML = op 
        let inputQuantity = document.querySelector(`#cantidadProducto-${idProduct}`)
        inputQuantity.value = op

        updateTotalAfterAddProduct(idProduct)
    }

    //Actualiza el texto de la cantidad de productos
    function lessQuantity(e){
        e.preventDefault

        let idProduct = e.currentTarget.getAttribute('data-id')
        let spanQuantity = document.querySelector(`#quantity-${idProduct}`)
        if(spanQuantity.innerHTML > 1){

            updateTotalAfterLessProduct(idProduct)

            let op = parseInt(spanQuantity.innerHTML) - 1
            spanQuantity.innerHTML = op 
            let inputQuantity = document.querySelector(`#cantidadProducto-${idProduct}`)
            inputQuantity.value = op

        }
    }

    //Elimina un producto de la tabla productos
    function deleteProduct(e){
        e.preventDefault

        let idProduct = e.currentTarget.getAttribute('data-id')
        
        updateTotalAfterDelete(idProduct)
        
        document.querySelector(`#idProducto-${idProduct}`).remove()
        document.querySelector(`#nombreProducto-${idProduct}`).remove() 
        document.querySelector(`#precioProducto-${idProduct}`).remove() 
        document.querySelector(`#cantidadProducto-${idProduct}`).remove()

        document.querySelector(`#tr-producto-${idProduct}`).remove()
    }

    //Agrega el evento de escucha a los botones de aumento, disminución y eliminación de producto
    let addListenerButtonAddLessDelete= ()=>{
        buttonsAdd.forEach((button)=>{
            button.addEventListener('click', addQuantity)
        })

        buttonsLess.forEach((button)=>{
            button.addEventListener('click', lessQuantity)
        })

        buttonsDelete.forEach((button)=>{
            button.addEventListener('click', deleteProduct)
        })
    }

    //Se agrega un evento al select de productos
    selectProducts.addEventListener('change', (e) =>{
        let idproduct = selectProducts.value
        let product = document.querySelector(`#producto-${idproduct}`)
       
        formSale.insertAdjacentHTML('beforeend', templateInputProducto(product))

        table.insertAdjacentHTML('beforeend', templateRow(product))
        
        if(inputCobro.hasAttribute('disabled')){ //Activa el uso del input para el cobro
            inputCobro.removeAttribute('disabled')
            buttonCobro.removeAttribute('disabled')
        }

        setTotal(product)
        
        refreshListButton()
        addListenerButtonAddLessDelete()
    })

    //Evento de escucha del input de cobro para agregar el cambio de la venta total
    inputCobro.addEventListener('keyup', (e) =>{
        setCambio()
    })

    //Evento para el botón cobrar para validar las cantidades de total y el monto ingresado
    buttonCobro.addEventListener('click', (e) => {
        e.preventDefault()
        
        let enviarFormulario = true;

        if(inputCobro.value < spanTotal.innerHTML){
            Swal.fire({
                text: "La cantidad ingresada es menor al total de la venta",
                icon: 'warning',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'Aceptar'
            })
            enviarFormulario = false
        }

        if(enviarFormulario){
            //Se obtiene el total  y se agrega a un string con el formato de un input
            let totalVenta = spanTotal.innerHTML
            let inputTotalVenta = `
                <input type="hidden" id="totalVenta" 
                    name="totalVenta" 
                    value="${totalVenta}">
            `
            //Se agrega el input con el totoal de l venta
            formSale.insertAdjacentHTML('beforeend', inputTotalVenta)
            formSale.submit()
        }
    })

    

}