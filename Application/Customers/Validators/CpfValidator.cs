namespace Application.Customers.Validators;

public class CpfValidator
{
    public static bool IsInvalid(string? cpf)
    {
        return !ValidateCpf(cpf);
    }

    private static bool ValidateCpf(string cpf)
    {
        string new_cpf = "";
        for (int i = 0; i < cpf.Length; i++)
        {
            if (IsDigit(cpf.Substring(i, 1)))
            {
                new_cpf += cpf.Substring(i, 1);
            }
        }
 
        new_cpf = Convert.ToInt64(new_cpf).ToString("D11");
        if (new_cpf.Length > 11)
        {
            return false;
        }
        
        if (CalcDigCpf(new_cpf.Substring(0, 9)) == new_cpf.Substring(9, 2))
        {
            return true;
        }
 
        return false;
    }
    
    private static string CalcDigCpf(string cpf)
    {
        // Declara variaveis para uso
        string new_cpf ="";
        string digito = "";
        Int32 Aux1 = 0;
        Int32 Aux2 = 0;
 
        // Retira carcteres invalidos não numericos da string
        for (int i =0;i<cpf.Length;i++)
        {
            if(IsDigit(cpf.Substring(i,1)))
            {
                new_cpf += cpf.Substring(i, 1);
            }
        }
 
        // Ajusta o Tamanho do CPF para 9 digitos completando com zeros a esquerda
        new_cpf = Convert.ToInt64(new_cpf).ToString("D9");
 
        // Caso o tamanho do CPF informado for maior que 9 digitos retorna nulo
        if (new_cpf.Length > 9)
        {
            return null;
        }
 
        // Calcula o primeiro digito do CPF
        Aux1 = 0;
 
        for (int i = 0; i < new_cpf.Length; i++)
        {
            Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (10-i);          
        }
 
        Aux2 = 11 - (Aux1 % 11);
 
        // Carrega o primeiro digito na variavel digito
        if (Aux2 > 9)
        {
            digito += "0";
        }
        else
        {
            digito += Aux2.ToString();
        }
 
        // Adiciona o primeiro digito ao final do CPF para calculo do segundo digito
        new_cpf += digito;
         
        // Calcula o segundo digito do CPF
        Aux1 = 0;
 
        for (int i = 0; i < new_cpf.Length; i++)
        {
            Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (11 - i);
        }
 
        Aux2 = 11 - (Aux1 % 11);
 
        // Carrega o segundo digito na variavel digito
        if (Aux2 > 9)
        {
            digito += "0";
        }
        else
        {
            digito += Aux2.ToString();
        }
 
        return digito;
    }
    
    private static bool IsDigit(string digito)
    {
        int n;
        return Int32.TryParse(digito, out n);
    }
}