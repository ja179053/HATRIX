using UnityEngine;
using UnityEngine.Purchasing;
using System.Collections;

public class BuyPoints : MonoBehaviour, IStoreListener {
	static IStoreController storeController;
	static IExtensionProvider extensionProvider;
	static string consumableProductString = "consumable", nonconsumableProductString = "non-consumable";

	// Use this for initialization
	void Start () {
		if (storeController == null) {
			InitialisePurchasing ();
		}
	}
	void InitialisePurchasing(){
		if (IsInitialised ()) {
			return;
		}
		var configBuilder = ConfigurationBuilder.Instance (StandardPurchasingModule.Instance ());
		configBuilder.AddProduct (consumableProductString, ProductType.Consumable);
		configBuilder.AddProduct (nonconsumableProductString, ProductType.NonConsumable);
		UnityPurchasing.Initialize (this,configBuilder);
	}
	bool IsInitialised(){
		return storeController != null && extensionProvider != null;
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void PurchasePoints(){
		BuyProductID (consumableProductString);
	}
	void BuyProductID(string productID){
		Product product = storeController.products.WithID (productID);

		if (product != null && product.availableToPurchase) {
			storeController.InitiatePurchase (product);
		}
	}
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions){
		Debug.Log ("Initialised");
		storeController = controller;
		extensionProvider = extensions;
	}
	public void OnInitializeFailed(InitializationFailureReason reason){
		Debug.Log ("INITIALISATION FAILED! " + reason);
	}
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args){
		if(args.purchasedProduct.definition.id == consumableProductString){
			//£1 = 100 carrots;
			MinigameHead.score += 500;
		} else if (args.purchasedProduct.definition.id == nonconsumableProductString) {
			//Buy new product.
		}
		return PurchaseProcessingResult.Complete;
	}
	public void OnPurchaseFailed(Product product, PurchaseFailureReason reason){
		Debug.Log ("THE PURCHASE FAILED! " + reason);
	}
}
