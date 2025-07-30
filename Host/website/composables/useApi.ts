export const useApi = () => {
    const token = localStorage.getItem('access_token');

    const $fetchWithAuth = (url: string, options = {}) => {
        return $fetch(url, {
            ...options,
            headers: {
                ...(options as any).headers,
                Authorization: `Bearer ${token}`,
            },
            onResponseError({ response }) {
                if (response.status === 401 || response.status === 403) {
                    // مثلاً برو صفحه لاگین
                    navigateTo('/login');
                }
            },
        });
    };

    return { $fetchWithAuth };
};
