<template>
    <div class="barraTop">
        <nav class="marginPrincial">
            <router-link to="/professores">Professor</router-link>
            <router-link to="/todos-alunos">Aluno</router-link>
            <router-link to="/sobre">Sobre</router-link>
        </nav>
    </div>
</template>

<script>
    export default {
        
    }
</script>

<style lang="scss" scoped>
.barraTop{
    background-color:rgb(230,230,230);
}
nav{
    padding: 20px;
    padding-left: 0;
    
}
nav a{
    padding: 10px;
    text-decoration: none;
    background: #fff;
    border-radius: 3px;
    color: rgb(0,110,255);
    font-weight: bold;
    margin-right: 15px;
}
nav .router-link-exact-active {
    background-color: rgb(160, 160, 160);
    color:white;
}
</style>