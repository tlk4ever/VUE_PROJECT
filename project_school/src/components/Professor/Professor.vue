<template>
    <div>
        <titulo texto="Professores" />
        <table>
            <thead>
                <tr>
                    <th>Cod.</th>
                    <th>Nome</th>
                    <th>Alunos</th>
                </tr>
            </thead>
            <tbody v-if="professores.length">
                <tr v-for="(professor, index) in professores" :key="index">
                    <td class="colPequeno">{{professor.id}}</td>
                    <router-link :to="`/alunos/${professor.id}`" tag="td" style="cursor:pointer">
                        {{professor.nome}} {{professor.sobrenome}}
                    </router-link>
                    <td class="colPequeno">
                        {{professor.qtdAlunos}}
                    </td>
                </tr>
            </tbody>
            <tfoot v-else>Nenhum Professor Cadastrado.</tfoot>
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
                professores: [],
                alunos:[]
            }
        },
        created() {
            this.$http.get("http://localhost:3000/alunos")
            .then(res => res.json())
            .then(alunos => {
                this.alunos = alunos;
                this.carregarProfessor();
            })
        },
        props: {},
        methods: {
            pegarQtdAlunosPorPorfessor() {
                this.professores.forEach((professor, index) => {
                    professor = {
                        id: professor.id,
                        nome: professor.nome,
                        sobrenome: professor.sobrenome,
                        qtdAlunos: this.alunos.filter(aluno => aluno.professor.id == professor.id).length
                    }
                    this.professores[index] = professor;
                });
            },
            carregarProfessor(){
                this.$http.get("http://localhost:3000/professores")
                .then(res => res.json())
                .then(professores =>  {
                    this.professores = professores;
                    this.pegarQtdAlunosPorPorfessor();
                })
            }
        },
    };
</script>

<style lang="scss" scoped>
.colPequeno{
    text-align:center; 
    width:15%;
}
</style>