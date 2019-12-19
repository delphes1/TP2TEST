using System;
using Xunit;
namespace dark_place_game.tests
{
    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";
        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal écrit, corrigez le.");
        }
        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }
        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }
        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }
        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void CreatingCurrencyHolderWithBigNameThrowExeption()
        {
            // Test si un nom est supérieur à 10 charactères
            Action mauvaisAppel = () => new CurrencyHolder("jesuisunlongname", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void BrouzoufIsAValidCurrencyName()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            CurrencyHolder currency = new CurrencyHolder("Brouzouf",EXEMPLE_CAPACITE_VALIDE ,EXEMPLE_CONTENANCE_INITIALE_VALIDE);

        }
        [Fact]
        public void DollardIsAValidCurrencyName()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            CurrencyHolder currency = new CurrencyHolder("Dollard",EXEMPLE_CAPACITE_VALIDE ,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
        }
        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            CurrencyHolder currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE/2, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            currency.Put(10);
            Assert.True(currency.CurrentAmount == EXEMPLE_CONTENANCE_INITIALE_VALIDE + 10);
        }
        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
            
            Action mauvaisAppel = () => {
                CurrencyHolder currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,10,9);
                currency.Put(10);
            };
            
            Assert.Throws<NotEnoughtSpaceInCurrencyHolderExeption>(mauvaisAppel);

        }
        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il est possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("del", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            Action mauvaisAppel = () => {
                CurrencyHolder currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,10,9);
                currency.Withdraw(-5);
            };
            
            Assert.Throws<CantWithDrawNegativeCurrencyAmountExeption>(mauvaisAppel);
        }
        [Fact]
        public void PutNegativeCurrentAmountInCurrencyHolderThrowExeption(){
            Action mauvaisAppel = () => {
                CurrencyHolder currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,10,9);
                currency.Put(-5);
            };
            
            Assert.Throws<CantPutNegativeCurrencyAmountExeption>(mauvaisAppel);
        }
        [Fact]
        public void PutNullCurrencyAmountExeption(){
            Action mauvaisAppel = () => {
                CurrencyHolder currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,10,9);
                currency.Put(0);
            };
            
            Assert.Throws<CantPutNullCurrencyAmountExeption>(mauvaisAppel);  
        }
        [Fact]
        public void WithDrawNullCurrencyAmountExeption(){
            Action mauvaisAppel = () => {
                CurrencyHolder currency = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE,10,9);
                currency.Withdraw(0);
            };
            
            Assert.Throws<CantWithDrawNullCurrencyAmountExeption>(mauvaisAppel);  
        }
        [Fact]
        public void IfStartACurrencyAmountException(){
            Action mauvaisAppel = () => new CurrencyHolder("acolyte", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void IfStartaCurrencyAmountException(){
            Action mauvaisAppel = () => new CurrencyHolder("Acolyte", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void CreatingCurrencyHolderWithLessThanOneCapacityThrowExeption(){
            Action mauvaisAppel = () => new CurrencyHolder("Exemple", 0, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }
        [Fact]
        public void CreatingCurrencyHolderWithMinimumOneCapacityThrowExeption(){
            CurrencyHolder currency = new CurrencyHolder("Exemple",1,EXEMPLE_CONTENANCE_INITIALE_VALIDE);
        }
        [Fact]
        public void CheckisNotEmpty(){
            CurrencyHolder currency = new CurrencyHolder("Exemple",1,0);
            currency.Put(1);
            var result = currency.IsEmpty();
            Assert.False(result);
        }
        [Fact]
        public void CheckisEmpty(){
            CurrencyHolder currency = new CurrencyHolder("Exemple",1,0);
            var result = currency.IsEmpty();
            Assert.True(result);
        }
        [Fact]
        public void CheckisFull(){
            CurrencyHolder currency = new CurrencyHolder("Exemple",1,0);
            currency.Put(1);
            var result = currency.IsFull();
            Assert.True(result);
        }
        [Fact]
        public void CheckisNotFull(){
            CurrencyHolder currency = new CurrencyHolder("Exemple",2,0);
            currency.Put(1);
            var result = currency.IsFull();
            Assert.False(result);
        }
        [Fact]
        public void CheckisFullInitial(){
            CurrencyHolder currency = new CurrencyHolder("Exemple",2,2);
            var result = currency.IsFull();
            Assert.True(result);
        }
        [Fact]
        public void CheckisNotFullInitial(){
            CurrencyHolder currency = new CurrencyHolder("Exemple",2,0);
            var result = currency.IsFull();
            Assert.False(result);
        }
    }
}
