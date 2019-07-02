import Vue from 'vue';
import Router from 'vue-router';
import Alunos from './components/Aluno/Alunos.vue';
import Professor from './components/Professor/Professor.vue';
import Sobre from './components/Sobre/Sobre.vue';

Vue.use(Router);

export default new Router({
    routes :[
        {
            path: '/professores',
            name : 'Professores',
            component: Professor
        },
        {
            path: '/alunos/:professor_id',
            name : 'Alunos',
            component: Alunos
        },
        {
            path: '/todos-alunos',
            name : 'Alunos',
            component: Alunos
        },
        {
            path: '/sobre',
            name : 'Sobre',
            component: Sobre
        }
    ]
})