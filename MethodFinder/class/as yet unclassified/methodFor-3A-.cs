methodFor: dataAndAnswers
	"Return a Squeak expression that computes these answers.  (This method is called by the comment in the bottom pane of a MethodFinder.  Do not delete this method.)"

	| resultOC selFinder resultString |
	resultOC _ (self new) load: dataAndAnswers; findMessage.
	resultString _ String streamContents: [:strm |
		resultOC do: [:exp | strm nextPut: $(; nextPutAll: exp; nextPut: $); space]].
	Smalltalk isMorphic ifTrue: [
		selFinder _ (ActiveWorld 
				submorphThat: [:mm | mm class == SystemWindow and: 
									[mm model isKindOf: SelectorBrowser]] 
				ifNone: [^ resultString]) model.
		selFinder searchResult: resultOC].
	^ resultString