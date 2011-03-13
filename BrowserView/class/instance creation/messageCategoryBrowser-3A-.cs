messageCategoryBrowser: aBrowser 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of three subviews, starting with the list view of message categories in 
	the model's currently selected class. The initial text view part is empty."

	^self messageCategoryBrowser: aBrowser editString: nil