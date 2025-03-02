import { Curriculum } from "../Models/Curriculum";
import { api } from "../utils/axios";

const Post = async (curriculum: Partial<Curriculum> ) => {
    await api.post('/', {
        name: curriculum.name,
        email: curriculum.email,
        formation: curriculum.formation,
        phoneNumber: curriculum.phoneNumber
    });
}

const Get = async () => {
    const response = await api.get<Curriculum[]>('/');
    return response.data;
}

const Edit = async (curriculum: Curriculum) => {
    await api.put(`/${curriculum.id}`, {
        name: curriculum.name,
        email: curriculum.email,
        formation: curriculum.formation,
        phoneNumber: curriculum.phoneNumber
    });
}

const Delete = async (id: number) => {
    await api.delete(`/${id}`);
};

export const CurriculumService = { 
    Post, 
    Get, 
    Edit, 
    Delete 
}