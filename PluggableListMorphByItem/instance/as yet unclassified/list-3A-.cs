list: arrayOfStrings
	"Set the receivers items to be the given list of strings."
	"Note: the instance variable 'items' holds the original list.
	 The instance variable 'list' is a paragraph constructed from
	 this list."

	itemList _ arrayOfStrings.
	^ super list: arrayOfStrings