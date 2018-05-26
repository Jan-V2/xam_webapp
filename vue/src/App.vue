<template>
    <div id="app">

    <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top" @click="close_navbar()">
        <a class="navbar-brand" href="#">Navbar</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarsExampleDefault">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="#/">Home <span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#/wiki">wiki search</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link disabled" href="#">Disabled</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="http://example.com" id="dropdown01" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Dropdown</a>
                    <div class="dropdown-menu" aria-labelledby="dropdown01">
                        <a class="dropdown-item" href="#">Action</a>
                        <a class="dropdown-item" href="#">Another action</a>
                        <a class="dropdown-item" href="#">Something else here</a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
    <main role="main" class="container">

        <div class="starter-template">
            <h1>Bootstrap starter template</h1>
        </div>

    </main>





        <router-view/>
    </div>
</template>

<script>
    export default {
        name: 'App',
        beforeCreate: function(){
            $("#loading_txt").css('visibility', 'none');
        },
        methods: {
            close_navbar: function () {
                console.log("closing");
                $('.navbar-collapse').collapse('hide');
            }
        }
    }
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        /*margin-top: 60px;*/
    }
</style>
