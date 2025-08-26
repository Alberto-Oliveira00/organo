import './ListaSuspensa.css'

const ListaSuspensa = ({label, items,  valor, aoAlterado, obrigatorio = false}) => {
    return (
    <div className="lista-suspensa">
        <label>{label}</label>
        <select 
            required={obrigatorio} 
            value={valor} 
            onChange={evento => aoAlterado(evento.target.value)}
        >
            <option value="">Selecione um time</option>
            {items.map((t) => (
                <option key={t.timeID} value={t.timeID}>
                    {t.nomeTime}
                </option>
            ))}
        </select>
    </div>
    )
}

export default ListaSuspensa