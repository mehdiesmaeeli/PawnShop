<template>
    <div class="max-w-md mx-auto">
        <h2 class="text-2xl font-semibold mb-4">Login</h2>
        <div class="mb-4">
            <label for="email" class="block text-sm font-medium">Phone</label>
            <input v-model="email" type="email" id="email" class="w-full p-2 border rounded" />
        </div>
        <div class="mb-4">
            <label for="password" class="block text-sm font-medium">Password</label>
            <input v-model="password" type="password" id="password" class="w-full p-2 border rounded" />
        </div>
        <button type="button" @click="login" class="bg-blue-500 text-white p-2 rounded">Login</button>
        <p v-if="error" class="text-red-500 mt-2">{{ error }}</p>
    </div>
</template>

<script setup>
    import { ref } from 'vue'

    const email = ref('')
    const password = ref('')
    const error = ref('')

    const login = async () => {
        try {
            const { data, error } = await useFetch('http://localhost:5004/api/auth/login', {
                method: 'POST',
                body: {
                    email: email.value,
                    password: password.value
                }
            });
            debugger;
            if (error.value) throw error.value;

            localStorage.setItem('access_token', data.value.data);

        } catch (err) {
            error.value = 'Login failed. Please check your credentials.'
        }
    }
</script>