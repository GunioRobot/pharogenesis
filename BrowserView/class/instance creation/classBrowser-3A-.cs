classBrowser: aBrowser 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of four subviews, starting with the list view of classes in the model's 
	currently selected system category. The initial text view part is empty."

	^self classBrowser: aBrowser editString: nil