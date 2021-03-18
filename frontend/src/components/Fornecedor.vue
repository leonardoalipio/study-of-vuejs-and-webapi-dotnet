<template>
	<div class="col-md-4">
      <div class="row no-gutters border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
        <div class="col p-4 d-flex flex-column position-static">
          <strong class="d-inline-block mb-2 text-primary">Parceiros**</strong>
          <h3 class="mb-0">{{ TopFornecedor.nome }}</h3>
          <div class="mb-1 text-muted">Ativo: {{ TopFornecedor.ativo ? 'Sim' : 'Não' }}</div>
          <p class="card-text mb-auto">{{ TopFornecedor.descricao }}</p>
          <a class="stretched-link" @click="abrirFornecedor(TopFornecedor)">Sobre este fornecedor</a>
        </div>
      </div>
    </div>
</template>

<script>
import { Prop, Component, Vue } from 'vue-property-decorator'

@Component({
  name: 'Fornecedor'
})
export default class Fornecedor extends Vue {
    
    @Prop({ required: true }) TopFornecedor;

    abrirFornecedor(fornecedor) {
        // this.$router.push({
        //     path: `/fornecedor/${fornecedor.id}`
        // })
        console.log(fornecedor)
    }

    created() {
        console.log(this.TopFornecedor)
    }
    
}
</script>

<style>

</style>