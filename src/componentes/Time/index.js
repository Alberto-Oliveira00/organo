import Colaborador from '../Colaborador'
import './Time.css'

const Time = (props) => {
    // const css = {backgroundColor: props.corSecundaria} 
    // Outra forma de usar a variavel para os estilos

    return (
        (props.colaboradores.length > 0) && <section className='time' style={{ backgroundColor: props.corSecundaria }}>
            <h3 style={{ borderColor: props.corPrimaria }}>{props.nome}</h3>
            <div>
                {props.colaboradores.map( colaborador => <Colaborador nome={colaborador.nome} cargo={colaborador.cargo} 
                imagem={colaborador.imagem} /> )}
            </div>
        </section>
    )
}

export default Time