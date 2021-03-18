<template>
	<div>
        <NavBar />

        <div class="container-fluid">
            <div class="row">

                <SideBar />

                <Content />

            </div>
        </div>

        <Footer />
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator'

    @Component
    export default class Layout extends Vue {
        
    }
</script>

<style>

</style>