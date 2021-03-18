<template>
	<footer class="footer mt-auto py-3 fixed-bottom">
		<div class="container">
			<span>Place sticky footer content here.</span>
		</div>
	</footer>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator'

    @Component
    export default class Footer extends Vue {
        
    }
</script>

<style>
    footer {
        background-color: #2b7489;        
    }

    footer span {
        color: #FFF;
    }
</style>