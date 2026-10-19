using System;

namespace CoreLib
{
    public class Utils
    {

        public string GenerateOrderNumber(Client client, DateTime dateTime)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (string.IsNullOrWhiteSpace(client.LastName) ||
                string.IsNullOrWhiteSpace(client.FirstName) ||
                string.IsNullOrWhiteSpace(client.MiddleName))
                throw new ArgumentException("ФИО клиента заполнено не полностью");

            char firstInitial = char.ToUpper(client.FirstName[0]);
            char middleInitial = char.ToUpper(client.MiddleName[0]);

            return $"{client.LastName}_{firstInitial}.{middleInitial}._" +
                   $"{dateTime:MM.dd.yyyy_HH_mm}";
        }
    }
}