messageBrowser: aBrowser 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of two subviews, starting with the list view of message selectors in the 
	model's currently selected category. The initial text view part is empty."

	^self messageBrowser: aBrowser editString: nil