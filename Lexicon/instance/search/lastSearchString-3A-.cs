lastSearchString: aString
	"Make a note of the last string searched for in the receiver"

	currentQueryParameter := aString asString.
	currentQuery := #selectorName.
	autoSelectString := aString.
	self setMethodListFromSearchString.
	^ true