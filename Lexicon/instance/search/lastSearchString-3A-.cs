lastSearchString: aString
	"Make a note of the last string searched for in the receiver"

	currentQueryParameter _ aString asString.
	currentQuery _ #selectorName.
	autoSelectString _ aString.
	self setMethodListFromSearchString.
	^ true