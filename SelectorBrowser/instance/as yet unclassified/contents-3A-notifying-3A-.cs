contents: aString notifying: aController
	"Take what the user typed and find all selectors containing it"

	| tokens |
	contents _ aString.
	classList _ #().  classListIndex _ 0.
	selectorIndex _ 0.
	tokens _ contents asString findTokens: ' .'.
	selectorList _ Cursor wait showWhile: [
		tokens size = 1 
			ifTrue: [(Symbol selectorsContaining: contents asString) asSortedArray]
			ifFalse: [self quickList]].	"find selectors from a single example of data"
	self changed: #messageList.
	self changed: #classList.
	^ true