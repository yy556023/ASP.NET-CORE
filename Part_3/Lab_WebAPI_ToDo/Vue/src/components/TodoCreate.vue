<template>
    <div class="container">
        <h1>待辦事項清單 - 新增</h1>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <form>

                    <div class="form-group">
                        <label class="control-label" for="Name">項目名稱</label>
                        <input class="form-control" type="text" id="Name"
                               name="Name" v-model="todoItemName" />
                    </div>
                    <div class="form-group form-check">
                        <label class="form-check-label">
                            <input class="form-check-input" type="checkbox" id="IsComplete"
                                   name="IsComplete" v-model="todoItemIsComplete" /> 是否已完工
                        </label>
                    </div>
                    <div class="form-group">
                        <input type="button" v-on:click="doOkButtonClick" value="確定" class="btn btn-outline-primary" /> |
                        <router-link to="/Todo/Index" class="btn btn-outline-info">取消</router-link>
                    </div>
                </form>
            </div>
        </div>
    </div>
 
</template>


<script>
    import axios from 'axios'
    export default {
        name: "TodoCreate",
        data() {
            return {
                todoItemName: "",
                todoItemIsComplete: false
            }
        },
        methods: {
            getTodoItemList() {
                axios.get('/api/todoitem')
                    .then((response) => {
                        this.todoItemList = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            doOkButtonClick() {
                
               
                var dataToServer = {
                    Name: this.todoItemName,
                    IsComplete: this.todoItemIsComplete,
                };

 
                axios
                    .post("/api/todoitem",
                        JSON.stringify(dataToServer),
                        { headers: { 'Content-Type': 'application/json' } })
                    .then((response) => {
                        this.$router.replace('/Todo/Index');
                        console.log(response);
                    })
            }
        },
        mounted() {
            this.getTodoItemList();
        }
    }
</script>