contents: aString notifying: aController
	"Take what the user typed and find all selectors containing it"

	| tokens raw sorted |
	contents _ aString.
	classList _ #().  classListIndex _ 0.
	selectorIndex _ 0.
	tokens _ contents asString findTokens: ' .'.
	selectorList _ Cursor wait showWhile: [
		tokens size = 1 
			ifTrue: [raw _ (Symbol selectorsContaining: contents asString).
				sorted _ raw as: SortedCollection.
				sorted sortBlock: [:x :y | x asLowercase <= y asLowercase].
				sorted asArray]
			ifFalse: [self quickList]].	"find selectors from a single example of data"
	self changed: #messageList.
	self changed: #classList.
	^ true