methodFor: dataAndAnswers
	"Return an expression that computes these answers."

	| result selFinder |
	result _ (self new) load: dataAndAnswers; findMessage.
	Smalltalk isMorphic ifTrue: [
		((selFinder _ World submorphs first model) 
			isKindOf: SelectorBrowser) ifTrue: [
	 			selFinder searchResult: result]].
	^result