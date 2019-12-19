using System;
namespace dark_place_game
{
    [System.Serializable]
    /// Une Exeption Custom
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception { }
    public class CantWithDrawNegativeCurrencyAmountExeption : System.Exception { }
    public class CantPutNegativeCurrencyAmountExeption : System.Exception { }
    public class CantPutNullCurrencyAmountExeption : System.Exception { }
    public class CantWithDrawNullCurrencyAmountExeption : System.Exception { }
    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";
        /// Le nom de la monnaie
        public string CurrencyName
        {
            get { return currencyName; }
            private set
            {
                currencyName = value;
            }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;
        /// Le montant actuel
        public int CurrentAmount
        {
            get { return currentAmount; }
            private set
            {
                currentAmount = value;
            }
        }
        // Le champs interne de la property
        private int currentAmount = 0;
        /// La contenance maximum du conteneur
        public int Capacity
        {
            get { return capacity; }
            private set
            {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;
        public CurrencyHolder(string name, int capacity, int amount)
        {

            if(name == null){
                throw new System.ArgumentException("Parameter cannot be null", "name");
            }else if(name == ""){
                throw new System.ArgumentException("Parameter cannot be empty", "name");
            }else if(name.Substring(0, 1).Equals("a") || name.Substring(0, 1).Equals("A")){
                throw new System.ArgumentException("Parameter cannot be a or A");
            }else if(amount < 0){
                throw new System.ArgumentException("Parameter cannot be negative", "amount");
            }else if(name.Length > 10){
                throw new System.ArgumentException("Parameter cannot be more than 10 characters", "name");
            }else if(name.Length < 4){
                throw new System.ArgumentException("Parameter cannot be less than 4 characters", "name");
            }else if(capacity < 1){
                throw new System.ArgumentException("Parameter cannot be less than 1", "capacity");
            }
            
            Capacity = capacity;
            CurrencyName = name;
            CurrentAmount = amount;
        }
        public bool IsEmpty()
        {
            if(CurrentAmount == 0){
            return true;
            }else{
                return false;
            }
        }
        public bool IsFull()
        {   
            if(CurrentAmount == Capacity){
                return true;
            }else{
                return false;
            }
            
        }
        public void Store(int amount)
        {
            if(currentAmount + amount > Capacity){
                throw new NotEnoughtSpaceInCurrencyHolderExeption();
            }else{
                currentAmount = currentAmount + amount;
            }  
        }
        public void Put (int amount)
        {   if(amount < 0){
                throw new CantPutNegativeCurrencyAmountExeption();
            }else if(amount == 0){
                    throw new CantPutNullCurrencyAmountExeption();
                }else{
                if(currentAmount + amount > Capacity){
                    throw new NotEnoughtSpaceInCurrencyHolderExeption();
                }else{
                    currentAmount = currentAmount + amount;
                }    
            }
        }
        public void Withdraw(int amount)
        {
            if(amount < 0){
                throw new CantWithDrawNegativeCurrencyAmountExeption();
            }else if(amount == 0){
                throw new CantWithDrawNullCurrencyAmountExeption();
                }else{
                currentAmount = currentAmount - amount;
            } 
            
        }
    }
}
