<template>
	<nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
      <div class="sidebar-sticky pt-3">
        <ul class="nav flex-column">

            <SideBarLink name="Dashboard" icon="fas fa-home" href="/" />
            <SideBarLink name="Customers" icon="fas fa-users" href="/fornecedores" />
            <SideBarLink name="New Customers" icon="fas fa-copy" href="/novo-fornecedor" />
            <SideBarLink name="Products" icon="fas fa-shopping-cart" href="/produtos" />
          
        </ul>
      </div>
    </nav>
</template>

<script>
import SideBarLink from '@/layout/SideBar/SideBarLink'

export default {
    components: { SideBarLink }
}
</script>

<style>

</style>