changeSetListKey: aChar from: view
	"Respond to a Command key.  I am a model with a listView that has a list of changeSets."
	aChar == $f ifTrue: [^ self findCngSet].
	^ self arrowKey: aChar from: view