namespace Templ4te.V1.Infra.CrossCutting.Common
{
    public static class StringExtension
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string RemoveMask(this string texto)
        {
            return string.IsNullOrEmpty(texto) ? texto : texto
                .Replace("/", string.Empty)
                .Replace("-", string.Empty)
                .Replace("_", string.Empty)
                .Replace(".", string.Empty)
                .Replace(",", string.Empty)
                .Replace("(", string.Empty)
                .Replace(")", string.Empty)
                .Replace(" ", string.Empty);
        }

        public static string ToCpf(this string texto)
        {
            texto = texto.RemoveMask();
            if (texto.Length != 11)
                return "CPF Inválido";

            texto = $"{texto.Substring(0, 3)}.{texto.Substring(3, 3)}.{texto.Substring(6, 3)}-{texto.Substring(9, 2)}";
            return texto;
        }

        public static string ToCep(this string texto)
        {
            texto = texto.RemoveMask();
            if (texto.Length != 8)
                return texto;
            texto = texto.Substring(0, 2) + "." + texto.Substring(2, 3) + "." + texto.Substring(5, 3);
            return texto;
        }


        public static string RemoverAcentuacao(this string texto)
        {
            return texto.Replace('á', 'a').Replace('à', 'a').Replace('Á', 'A').Replace('À', 'A')
                .Replace('é', 'e').Replace('è', 'e').Replace('É', 'E').Replace('È', 'E')
                .Replace('í', 'i').Replace('ì', 'i').Replace('Í', 'I').Replace('Ì', 'I')
                .Replace('ó', 'o').Replace('ò', 'o').Replace('Ó', 'O').Replace('Ò', 'O')
                .Replace('ú', 'u').Replace('ù', 'u').Replace('Ú', 'U').Replace('Ù', 'U')
                .Replace('ã', 'a').Replace('Ã', 'A').Replace('õ', 'o').Replace('Õ', 'O')
                .Replace('ç', 'c').Replace('Ç', 'C');
        }

        public static string ToTelefone(this string texto)
        {
            try
            {
                texto = texto.RemoveMask();

                if (texto.Length == 8)
                    return $"{texto.Substring(0, 4)}-{texto.Substring(4, 4)}";

                if (texto.Length == 10)
                    return $"({texto.Substring(0, 2)}){texto.Substring(2, 4)}-{texto.Substring(6, 4)}";

                if (texto.Length == 9 || texto.Length == 11)
                    return ToCelular(texto);

                return texto;
            }
            catch { return texto; }
        }

        public static string ToCelular(this string texto)
        {
            try
            {
                texto = texto.RemoveMask();

                if (texto.Length == 8)
                    return $"{texto.Substring(0, 4)}-{texto.Substring(4, 4)}";

                if (texto.Length == 9)
                    return $"{texto.Substring(0, 5)}-{texto.Substring(5, 4)}";

                return texto.Length == 11 ? $"({texto.Substring(0, 2)}){texto.Substring(2, 5)}-{texto.Substring(7, 4)}" : texto;
            }
            catch { return texto; }
        }
    }
}