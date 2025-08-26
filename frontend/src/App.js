import { useEffect, useState } from "react";
import Banner from "./componentes/Banner/Banner";
import Formulario from "./componentes/Formulario";
import Rodape from "./componentes/Rodape";
import Time from "./componentes/Time";
import { v4 as uuidv4 } from "uuid";

function App() {

  const [times, setTimes] = useState([]);
  const [colaboradores, setColaboradores] = useState([]);

  useEffect(() => {
    const carregarDados = async () => {
    try {
      const resTimes = await fetch("http://localhost:5146/api/time");
      const dadosTimes = await resTimes.json();

      const timesFormatados = dadosTimes.map(t => ({
        id: t.timeID,
        nome: t.nomeTime,
        cor: t.corPadrao || "#000000"
      }));
      setTimes(timesFormatados);

      const resColabs = await fetch("http://localhost:5146/api/colaborador");
      const dadosColabs = await resColabs.json();

      const colabsFormatados = dadosColabs.map(c => ({
        id: c.colaboradorID,
        nome: c.nome,
        cargo: c.cargo,
        imagem: c.imagem,
        timeID: c.timeID,
        favorito: false
      }));

      setColaboradores(colabsFormatados);
    }
    catch (error){
      console.error("Erro ao buscar dados:", error);
    }
  };

  carregarDados();
  }, []);


  async function deletarColaborador(id) {
    try {
      const response = await fetch(`http://localhost:5146/api/colaborador/${id}`, {
        method: "DELETE"
      });

      if(!response.ok){
        throw new Error("Erro ao deletar colaborador");
      }

      setColaboradores(colaboradores.filter(c => c.id !== id));

    } catch (error) {
      console.log(error);
      alert("Falha ao deletar colaborador.");
    }
  }

  function mudarCorDoTime(cor, id) {
    setTimes(times.map(time => {
      if(time.id === id) {
        time.cor = cor;
      }
      return time;
    }));
  }

  function cadastrarTime(novoTime) {
    setTimes([...times, {...novoTime, id:uuidv4(), cor: novoTime.cor || "#000000" }]);
  }

  function resolverFavorito(id) {
    setColaboradores(colaboradores.map(colaborador => {
      if(colaborador.id === id) colaborador.favorito = !colaborador.favorito;
      return colaborador;
    }));
  } 

  return (
    <div>
      <Banner />
      <Formulario 
        cadastrarTime={cadastrarTime}
        times={times} 
        aoCadastrar={colaborador => setColaboradores([...colaboradores, colaborador])} 
      />
      <section className="times">
        <h1>Minha organização</h1>
        {times.map((time) => 
          <Time 
            key={time.id} 
            time={time} 
            colaboradores={colaboradores.filter(c => c.timeID === time.id)} 
            aoFavoritar={resolverFavorito}
            mudarCor={mudarCorDoTime}
            aoDeletar={deletarColaborador}
          />
        )}
      </section>
      <Rodape />
    </div>
  );
}

export default App;
