import './Time.css'

const Time = (props) => {
    // const css = {backgroundColor: props.corSecundaria} 
    // Outra forma de usar a variavel para os estilos

    return (
        <section className='time' style={{ backgroundColor: props.corSecundaria }}>
            <h3 style={{ borderColor: props.corPrimaria }}>{props.nome}</h3>
        </section>
    )
}

export default Time