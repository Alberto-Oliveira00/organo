import { useState } from 'react'
import Botao from '../Botao'
import Campo from '../Campo'
import ListaSuspensa from '../ListaSuspensa'
import './Formulario.css'

const Formulario = ({aoCadastrar, times, cadastrarTime }) => {

    const [nome, setNome] = useState('')
    const [cargo, setCargo] = useState('')
    const [imagem, setImagem] = useState('')
    const [timeId, setTimeId] = useState('')
    const [nomeTime, setNomeTime] = useState('')
    const [corTime, setCorTime] = useState('')

    const aoSubmeter = async (evento) => {
        evento.preventDefault()
        
        if (!timeId) {
            alert('Selecione um time')
            return
        }

        const colaborador = {
            nome,
            cargo,
            imagem,
            timeID: Number(timeId),
        }

        try {
            const response = await fetch("http://localhost:5146/api/colaborador", {
                method: "POST",
                headers: { "Content-Type":"application/json" },
                body: JSON.stringify(colaborador)
            });

            if(!response.ok){
                const erroTexto = await response.text();
                throw new Error(`Erro ao cadastrar colaborador: ${erroTexto}`);
            }


            const colaboradorCriado = await response.json();
            aoCadastrar(colaboradorCriado);

            setNome('');
            setCargo('');
            setImagem('');
            setTimeId('');

        } catch (error) {
            console.log(error);
            alert("Falha ao cadastrar colaborador");
        }
    };

    const aoCriarTime = async (evento) => {
        evento.preventDefault();

        const novoTime = {
            nomeTime: nomeTime,
            corPadrao: corTime,
        };

        try {
            const response = await fetch("http://localhost:5146/api/time", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(novoTime)
            });

            if(!response.ok){
                throw new Error("Erro ao cadastrar time");
            }

            const timeCriado = await response.json();
            cadastrarTime(timeCriado);

            setNomeTime('');
            setCorTime('');
            
        } catch (error) {
            console.error(error);
            alert("Falha ao cadastrar time");
        }
    };

    return (
        <section className="formulario-container">
            <form className="formulario" onSubmit={aoSubmeter}>
                <h2>Preencha os dados para criar o card do colaborador.</h2>
                <Campo
                    obrigatorio={true}
                    label='Nome'
                    placeholder='Digite seu nome '
                    valor={nome}
                    aoAlterado={(valor) => setNome(valor)}/>
                <Campo
                    obrigatorio={true}
                    label='Cargo' 
                    placeholder='Digite seu cargo '
                    valor={cargo}
                    aoAlterado={valor => setCargo(valor)}/>
                <Campo 
                    label='Imagem' 
                    placeholder='Informe o endereço da imagem '
                    aoAlterado={(valor) => setImagem(valor)}/>
                <ListaSuspensa 
                    obrigatorio={true}
                    label='Times'
                    items={times.map(time => ({timeID: time.id, nomeTime: time.nome}))} 
                    valor={timeId}
                    aoAlterado={setTimeId}
                />
                <Botao texto='Criar card' />
            </form>

            <form className="formulario" onSubmit={aoCriarTime}>
                <h2>Preencha os dados para criar um novo time.</h2>
                <Campo
                    obrigatorio
                    label='Nome'
                    placeholder='Digite o nome do time'
                    valor={nomeTime}
                    aoAlterado={(valor) => setNomeTime(valor)}
                />
                <Campo
                    obrigatorio
                    type='color'
                    label='Cargo' 
                    placeholder='Digite a cor do time'
                    valor={corTime}
                    aoAlterado={valor => setCorTime(valor)}
                />
                <Botao texto='Criar um novo time' />
            </form>
        </section>
    )
}

export default Formulario