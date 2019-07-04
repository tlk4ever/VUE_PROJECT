<template>
    <div>
        <titulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="visualizando">
            <button class="btn btnEditar" @click="editar()">Editar</button>
        </titulo>
        <table>
            <tbody>
                <tr>
                    <td class="colPequeno">Matrícula:</td>
                    <td>
                        <label>{{aluno.id}}</label>
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Nome:</td>
                    <td>
                        <label v-if="visualizando">{{aluno.nome}}</label>
                        <input v-else type="text" v-model="aluno.nome">
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Sobrenome:</td>
                    <td>
                        <label v-if="visualizando">{{aluno.sobrenome}}</label>
                        <input v-else type="text" v-model="aluno.sobrenome">
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Data Nascimento:</td>
                    <td>
                        <label v-if="visualizando">{{aluno.dataNasc}}</label>
                        <input v-else type="text" v-model="aluno.dataNasc">
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Professor:</td>
                    <td>
                        <label v-if="visualizando">{{professorAluno.nome}} {{professorAluno.sobrenome}}</label>
                        <select v-else v-model="professorAluno.id">
                            <option v-for="(professor, index) in professores" :key="index" :value="professor.id">
                                {{professor.nome}} {{professor.sobrenome}}</option>
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>
        <div style="margin-top:10px">
            <div v-if="!visualizando">
                <button class="btn btnSalvar" @click="salvar()">Salvar</button>
                <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
            </div>
        </div>
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
                aluno: {},
                professores: [],
                professorAluno: {},
                alunoId: this.$route.params.aluno_id,
                visualizando: true
            }
        },
        created() {
            this.$http.get(`${urlApi}/aluno/${this.alunoId}`)
                .then(res => res.json())
                .then(aluno => {
                    this.aluno = aluno;
                    this.professorAluno = aluno.professor;
                });

            this.$http.get(`${urlApi}/professor`)
                .then(res => res.json())
                .then(professores => this.professores = professores);
        },
        methods: {
            editar() {
                this.cancelar();
            },
            salvar() {
                let alunoEditar = {
                    id: this.aluno.id,
                    nome: this.aluno.nome,
                    sobrenome: this.aluno.sobrenome,
                    dataNasc: this.aluno.dataNasc,
                    professorid: this.professorAluno.id
                }
                this.$http.put(`${urlApi}/aluno/${this.aluno.id}`, alunoEditar)
                    .then(res => res.json())
                    .then(aluno => {
                        this.aluno = aluno;
                        this.professorAluno = aluno.professor;
                    });
                this.cancelar();
            },
            cancelar() {
                this.visualizando = !this.visualizando;
            }
        }
    }
</script>

<style lang="scss" scoped>
    .btnEditar {
        float: right;
        background-color: rgb(76, 186, 249);
    }

    .btnSalvar {
        float: right;
        background-color: rgb(79, 196, 68);
    }

    .btnCancelar {
        float: left;
        background-color: rgb(230, 15, 80);
    }

    .colPequeno {
        width: 20%;
    }

    input,
    select {
        margin: 0px;
        padding: 5px 10px;
        font-size: 0.9em;
        border: 1px solid silver;
        border-radius: 5px;
        font-family: Montserrat;
        width: 95%;
        background-color: rgb(245, 245, 245);
    }

    select {
        height: 38px;
        width: 100%;
    }
</style>