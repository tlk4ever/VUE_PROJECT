<template>
  <div>
    <titulo
      :texto="professorId != undefined ? 'Professor: ' + professor.nome + ' ' + professor.sobrenome : 'Todos os Alunos'" />
    <div v-if="professorId != undefined ">
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
          <td class="colPequeno">{{aluno.id}}</td>
          <router-link :to="`/aluno-detalhe/${aluno.id}`" tag="td" style="cursor:pointer">
            {{aluno.nome}} {{aluno.sobrenome}}
          </router-link>
          <td class="colPequeno">
            <button class="btn btn_danger" @click="remover(aluno)">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align:center">
            <h5>Nenhum Aluno Cadastrado.</h5>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
  import Titulo from "../_share/Titulo";
  var urlApi = "http://localhost:5000/api";
  export default {
    components: {
      Titulo
    },
    data() {
      return {
        nome: '',
        alunos: [],
        professor: {},
        professorId: this.$route.params.professor_id
      }
    },
    created() {

      let link = urlApi+"/aluno";
      if (this.professorId) {
        this.carregarProfessor();
        link = link + "/ByProfessor/" + this.professorId;
      }
      this.$http.get(link)
        .then(res => res.json())
        .then(alunos => this.alunos = alunos);
    },
    props: {},
    methods: {
      addAluno() {
        let _aluno = {
          nome: this.nome,
          sobrenome: "",
          dataNasc : "",
          professorid: this.professorId,
        };

        this.$http.post(`${urlApi}/aluno`, _aluno)
          .then(res => res.json())
          .then(aluno => {
            this.alunos.push(aluno);
            this.nome = "";
            console.log(aluno);
          })
      },
      remover(aluno) {

        this.$http.delete(`${urlApi}/aluno/${aluno.id}`)
          .then(() => {
            let indice = this.alunos.indexOf(aluno);
            this.alunos.splice(indice, 1);
          });
      },
      carregarProfessor() {
        this.$http.get(`${urlApi}/professor/${this.professorId}`)
          .then(res => res.json())
          .then(professor => {
            this.professor = professor;
          })
      }
    },
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  input {
    width: calc(100% - 195px);
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