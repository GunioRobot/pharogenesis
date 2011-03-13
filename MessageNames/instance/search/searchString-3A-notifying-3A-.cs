searchString: aString notifying: aController
	"Take what the user typed and find all selectors containing it"

	searchString := aString asString copyWithout: $ .
	self containingWindow setLabel: 'Message names containing "', searchString asLowercase, '"'.
	selectorList := nil.
	self changed: #selectorList.
	self changed: #messageList.
	^ true