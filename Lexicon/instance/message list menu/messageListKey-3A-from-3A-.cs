messageListKey: aChar from: view
	"Respond to a Command key"

	aChar == $f ifTrue: [^ self obtainNewSearchString].
	^ super messageListKey: aChar from: view