import axios from 'axios'

import Fornecedor from '@/types/Fornecedor'

export default class FornecedorService {

    public async getAllFornecedores(): Promise<Fornecedor[]> {

        const API_URL = process.env.VUE_APP_API_URL;
        const result = await axios.get(`${API_URL}/fornecedores`)
        return result.data;

    }
    
}