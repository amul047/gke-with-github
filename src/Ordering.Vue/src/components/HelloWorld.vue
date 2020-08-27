<template>
  <div>
    <h1>A serial front end developer just wanted to serially get the orders</h1>
    <div>{{orders}}</div>
  </div>
</template>

<script>
  import axios from 'axios'
  export default {
    name: 'Orders',
    data() {
      return {
        orders: "loading..."
      };
    },
    methods: {
      async getOrders() {
        this.orders = JSON.stringify(await axios.get("http://ordering-api-service:5000/orders"));
      }
    },
    async mounted() {
      await Promise.all([this.getOrders()]);
    },
  };

</script>
