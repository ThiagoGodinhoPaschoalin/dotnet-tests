using SharedDomain.Models;
using SharedDomain.Models.Associative;
using SharedDomain.Models.Enums;
using System;
using System.Collections.Generic;

namespace SharedDomain.Configurations
{
    public static class SeedData
    {
        #region accounts
        public static AccountModel Maite
            => new AccountModel("Maitê", "Baptista", GenderType.Female, "491.265.159-11", Guid.Parse("DEF31D5B-DCB0-46FA-89C7-ABA0BCFDB55C"));
        public static AccountModel Debora
            => new AccountModel("Débora", "Clarice", GenderType.Female, "086.198.466-80", Guid.Parse("3950A3B2-47AB-459E-BF44-F1C3065E0DFB"));
        public static AccountModel Ayla
            => new AccountModel("Ayla", "Ribeiro", GenderType.Female, "378.952.762-98", Guid.Parse("52675719-09BE-458E-8D0F-AE05D8629EC2"));
        public static AccountModel Pietra
            => new AccountModel("Pietra", "Conceição", GenderType.Female, "139.582.121-66", Guid.Parse("3762DB4A-8681-44D4-9CA6-BD9E0540D74F"));
        public static AccountModel Gabrielly
            => new AccountModel("Gabrielly", "Viana", GenderType.Female, "408.435.312-40", Guid.Parse("8CD6BCF9-53A7-49AC-AA0D-F230B0E05AFE"));
        public static AccountModel Thiago
            => new AccountModel("Thiago", "Godinho", GenderType.Male, "876.283.990-02", Guid.Parse("C6DA9A85-E385-455B-A217-AFF60A26C122"));
        public static AccountModel Benicio
            => new AccountModel("Benício", "Paschoalin", GenderType.Male, "529.480.900-16", Guid.Parse("B61D5D4D-C1F9-41C2-8323-2B11D9F64F52"));
        public static AccountModel Marcos
            => new AccountModel("Marcos", "Sebastião", GenderType.Male, "166.169.248-66", Guid.Parse("8108185D-CAF6-47B9-BD83-187A51F2C9C2"));
        public static AccountModel Andre
            => new AccountModel("André", "Cunha", GenderType.Male, "654.928.314-02", Guid.Parse("D6CD8238-873A-4B7A-A4B8-72C298B69E41"));
        public static AccountModel Thomas
            => new AccountModel("Thomas", "Rodrigues", GenderType.Male, "732.599.674-86", Guid.Parse("D48E1805-C298-4059-9FC3-8C8326A52F3A"));
        public static AccountModel Kaique
            => new AccountModel("Kaique", "Almada", GenderType.Male, "084.356.860-78", Guid.Parse("7BA1B661-DB11-4058-8A3E-1494C7FB9891"));
        #endregion

        #region profiles
        public static ProfileModel Aluno
            => new ProfileModel("Aluno", Guid.Parse("10FAE454-F200-41CE-B18F-112977AC18C1"));
        public static ProfileModel Professor
            => new ProfileModel("Professor", Guid.Parse("957F86A0-FB9A-4C2F-9F25-945EF4538CE5"));
        public static ProfileModel Gestor
            => new ProfileModel("Gestor", Guid.Parse("F732B923-4BE5-4A05-876F-AA7CBF38BFA6"));
        #endregion

        #region account_profiles
        public static AccountProfile ThiagoComoGestor
            => new AccountProfile(Thiago.Id, Gestor.Id, Guid.Parse("78213AEF-D461-4837-9248-AF2D03267E15"));
        public static AccountProfile MarcosComoAluno
            => new AccountProfile(Marcos.Id, Aluno.Id, Guid.Parse("D1C0DB63-FED6-431E-A6C0-3C2D5E853E30"));
        public static AccountProfile AndreComoAluno
            => new AccountProfile(Andre.Id, Aluno.Id, Guid.Parse("4B64C960-CFEB-4268-BE7C-D9FA1F98347B"));
        public static AccountProfile ThomasComoAluno
            => new AccountProfile(Thomas.Id, Aluno.Id, Guid.Parse("D1832A87-4786-4684-8B62-4D785E0CF566"));
        public static AccountProfile KaiqueComoAluno
             => new AccountProfile(Kaique.Id, Aluno.Id, Guid.Parse("B78FD645-EEF1-4D8D-9066-44438F23766C"));
        public static AccountProfile MaiteComoProfessora
            => new AccountProfile(Maite.Id, Professor.Id, Guid.Parse("DB3A7515-EF0A-42C3-8306-26B22DCB752D"));
        public static AccountProfile DeboraComoProfessora
             => new AccountProfile(Debora.Id, Professor.Id, Guid.Parse("92817BE0-E69F-4EC2-9A9A-9236AC7FA257"));
        public static AccountProfile AylaComoProfessora
            => new AccountProfile(Ayla.Id, Professor.Id, Guid.Parse("EBD4B227-D0C3-4B9B-BC61-2299284D0752"));
        public static AccountProfile PietraComoProfessora
            => new AccountProfile(Pietra.Id, Professor.Id, Guid.Parse("879EC6CB-80CD-4525-80EC-1FC86ED24A99"));
        public static AccountProfile GabriellyComoProfessora
            => new AccountProfile(Gabrielly.Id, Professor.Id, Guid.Parse("D723A151-F605-4097-B25A-2B892170D453"));
        #endregion

        public static IEnumerable<AccountModel> GetAccounts()
            => new[]
            {
                SeedData.Maite,
                SeedData.Debora,
                SeedData.Ayla,
                SeedData.Pietra,
                SeedData.Gabrielly,
                SeedData.Thiago,
                SeedData.Marcos,
                SeedData.Andre,
                SeedData.Thomas,
                SeedData.Kaique,
                SeedData.Benicio
            };

        public static IEnumerable<ProfileModel> GetProfiles()
            => new[]
            {
                SeedData.Aluno,
                SeedData.Professor,
                SeedData.Gestor
            };

        public static IEnumerable<AccountProfile> GetAssociativeAccountProfiles()
            => new[]
            {
                SeedData.ThiagoComoGestor,
                SeedData.MarcosComoAluno,
                SeedData.AndreComoAluno,
                SeedData.ThomasComoAluno,
                SeedData.KaiqueComoAluno,
                SeedData.MaiteComoProfessora,
                SeedData.DeboraComoProfessora,
                SeedData.AylaComoProfessora,
                SeedData.PietraComoProfessora,
                SeedData.GabriellyComoProfessora
            };
    }
}