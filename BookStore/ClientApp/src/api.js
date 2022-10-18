import axios from "axios";

const instance = axios.create({
    baseURL: "/api",
    headers: {
        "Content-Type": "application/json",
    },
});
instance.interceptors.request.use(
    (req) => {
        var token = localStorage.getItem('access-token');
        req.headers["Authorization"] = 'Bearer ' + token;
        return req
    },
    (error) => {
        return Promise.reject(error);
    }
);
instance.interceptors.response.use(
    (res) => {
        return res;
    },
    async (err) => {
        const originalConfig = err.config;
        if (originalConfig.url !== "/account/login" && err.response) {
            // Access Token was expired
            if (err.response.status === 401) {
                localStorage.removeItem('access-token');
                if (originalConfig._retry || originalConfig.url == "/account/refreshToken") {
                    window.location = '/login';
                } else {
                    originalConfig._retry = true;
                    try {
                        const rs = await instance.post("/account/refreshToken");
                        const { value } = rs.data;
                        localStorage.setItem('access-token', value);
                        return instance(originalConfig);
                    } catch (_error) {
                        return Promise.reject(_error);
                    }
                }
            }
        }
        return Promise.reject(err);
    }
);
export default instance;