systemCategoryBrowser: aBrowser 
	"Answer an instance of me on the model, aBrowser. The instance consists 
	of five subviews, starting with the list view of the currently selected 
	system class category--a single item list. The initial text view part is 
	empty."

	^self systemCategoryBrowser: aBrowser editString: nil