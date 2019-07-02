import Vue from 'vue';
import Router from 'vue-router';
import Alunos from './components/Aluno/Alunos.vue';
import AlunoDetalhe from './components/Aluno/AlunoDetalhe.vue';
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
            path: '/aluno-detalhe/:aluno_id',
            name : 'AlunoDetalhe',
            component: AlunoDetalhe
        },
        {
            path: '/todos-alunos',
            name : 'Aluno',
            component: Alunos
        },
        {
            path: '/sobre',
            name : 'Sobre',
            component: Sobre
        }
    ]
})