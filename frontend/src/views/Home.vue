<template>

    <div>
        <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">

            <h1 class="h2">Principais Fornecedores</h1>

            <div class="btn-toolbar mb-2 mb-md-0">

            <div class="btn-group mr-2">
                <button type="button" class="btn btn-sm btn-outline-secondary">Share</button>
                <button type="button" class="btn btn-sm btn-outline-secondary">Export</button>
            </div>

            <button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
                <span data-feather="calendar"></span>
                This week
            </button>

            </div>

        </div>

        <div class="row mb-2">
            <Fornecedor v-for="fornecedor in Fornecedores" 
                :key="fornecedor.id" 
                :TopFornecedor="fornecedor" />
        </div>

    </div>
    
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';

    import FornecedorService from '@/services/fornecedorService'

    import FornecedorModel from '@/types/Fornecedor'

    import AppFornecedorCard from '@/components/Fornecedor.vue'

    @Component({
        name: 'Home',
        components: {
            'Fornecedor': AppFornecedorCard
        }
    })
    export default class Home extends Vue {
        
        Fornecedores: FornecedorModel[] = [];

        created() {
            const fornecedorService = new FornecedorService();  

            fornecedorService.getAllFornecedores()
                .then(response => this.Fornecedores = response)
        }
        
    }
</script>
