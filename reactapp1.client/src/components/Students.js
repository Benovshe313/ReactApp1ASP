import { useEffect, useState } from "react";
import axios from "axios";
import { getAuthHeader } from "../services/authService";

const Students = () => {
    const [students, setStudents] = useState([]);

    useEffect(() => {
        const fetchStudents = async () => {
                const response = await axios.get("https://localhost:7063/api/students", {
                    headers: getAuthHeader()
                });
                setStudents(response.data);
           
        };
        fetchStudents();
    }, []);

    return (
        <ul>
            {students.map((student) => (
                <li key={student.id}>{student.fullname}</li>
            ))}
        </ul>
    );
};

export default Students;
