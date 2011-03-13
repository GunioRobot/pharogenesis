contents: aString notifying: aController
	"Take what the user typed and find all selectors containing it"

	| tokens raw sorted |
	contents := aString.
	classList := #().  classListIndex := 0.
	selectorIndex := 0.
	tokens := contents asString findTokens: ' .'.
	selectorList := Cursor wait showWhile: [
		tokens size = 1 
			ifTrue: [raw := (Symbol selectorsContaining: contents asString).
				sorted := raw as: SortedCollection.
				sorted sortBlock: [:x :y | x asLowercase <= y asLowercase].
				sorted asArray]
			ifFalse: [self quickList]].	"find selectors from a single example of data"
	self changed: #messageList.
	self changed: #classList.
	^ true