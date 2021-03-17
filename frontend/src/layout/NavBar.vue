<template>
	<nav class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap shadow">
		<a class="navbar-brand col-md-3 col-lg-2 text-center px-3" href="#">Company name</a>
		<button class="navbar-toggler position-absolute d-md-none collapsed" type="button" data-toggle="collapse" data-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="false" aria-label="Toggle navigation">
			<span class="navbar-toggler-icon"></span>
		</button>
		<ul class="navbar-nav px-3">
			<li class="nav-item text-nowrap">
			<a class="nav-link" href="#">Sign out</a>
			</li>
		</ul>
	</nav>
</template>

<script>
import { Component, Vue } from "vue-property-decorator";

@Component
export default class NavBar extends Vue{

}
</script>

<style>

</style>