<template>
    <div>
        <titulo :texto="`Aluno: ${aluno.nome}`" />
        <table>
        <tbody>
            <tr>
                <td class="colPequeno">Matricúla</td>
                <td></td>
            </tr>
            <tr>
                <td>Nome</td>
                <td></td>
            </tr>
            <tr>
                <td>Sobrenome</td>
                <td></td>
            </tr>
            <tr>
                <td>Professor</td>
                <td></td>
            </tr>
        </tbody>
    </table>
    </div>
</template>

<script>
import Titulo from "../_share/Titulo";
    export default {
        components:{
            Titulo
        },
        data(){
            return {
                aluno:{},
                alunoId : this.$route.params.aluno_id
            }
        },
        created(){
            this.$http.get("http://localhost:3000/alunos/" + this.alunoId)
            .then(res => res.json())
            .then(aluno => {
                this.aluno = aluno;
            })
        },
        methods:{

        }
    }
</script>

<style lang="scss" scoped>

</style>