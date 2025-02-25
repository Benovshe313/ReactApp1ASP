import axios from "axios";

const url = "https://localhost:7063/api/Account/SignIn";

export const login = async (username, password) => {
        const response = await axios.post(url, { username, password });
        const token = response.data; 
        localStorage.setItem("token", token);
};

export const getAuthHeader = () => {
    const token = localStorage.getItem("token");
    return {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
    };
};

export const getStudents = async () => {
    var headers = { authorization: "Bearer " + localStorage.getItem("token") };
    const response = await axios.get("https://localhost:7063/api/students", { headers });

    return response.data;
};
