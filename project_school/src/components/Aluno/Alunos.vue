<template>
  <div>
    <titulo texto="Alunos" />
    <div>
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()">
      <button class="btn btnInput" @click="addAluno()">Adicionar</button>
    </div>

    <table>
      <thead>
        <tr>
          <th>Mat.</th>
          <th>Nome</th>
          <th>Opções</th>
        </tr>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td>{{aluno.id}}</td>
          <td>{{aluno.nome}} {{aluno.sobrenome}}</td>
          <td>
            <button class="btn btn_danger" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum Aluno Cadastrado.
      </tfoot>
    </table>
  </div>
</template>

<script>
  import Titulo from "../_share/Titulo";
  export default {
    components: {
      Titulo
    },
    data() {
      return {
        nome: '',
        alunos: []
      }
    },
    created() {
      this.$http.get("http://localhost:3000/alunos")
        .then(res => res.json())
        .then(alunos => this.alunos = alunos)
    },
    props: {},
    methods: {
      addAluno() {
        let _aluno = {
          nome: this.nome,
          sobrenome : ""
        };

        this.$http.post("http://localhost:3000/alunos", _aluno)
          .then(res => res.json())
          .then(aluno => {
            this.alunos.push(aluno);
            this.nome = "";
          })
      },
      remover(aluno) {

        this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`)
          .then(()=>{
            let indice = this.alunos.indexOf(aluno);
          this.alunos.splice(indice, 1);
          });

      }
    },
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  input {
    border: 0;
    padding: 20px;
    font-size: 1.3em;
    color: black;
    display: inline;
  }

  .btnInput {
    width: 150px;
    border: 0px;
    padding: 20px;
    font-size: 1.3em;
    background-color: rgb(116, 115, 115);
  }

  .btnInput:hover {
    text-shadow: 1px 1px 1px black;
  }
</style>