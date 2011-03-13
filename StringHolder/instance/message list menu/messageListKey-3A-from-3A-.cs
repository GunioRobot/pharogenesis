messageListKey: aChar from: view
	"Respond to a Command key.  I am a model with a code pane, and I also have a listView that has a list of methods.  The view knows how to get the list and selection."

	| sel class |
	(sel _ self selectedMessageName) ifNil: [^ self arrowKey: aChar from: view].
	aChar == $m ifTrue: [Smalltalk browseAllImplementorsOf: sel].
	aChar == $n ifTrue: [Smalltalk browseAllCallsOn: sel].
	aChar == $b ifTrue: [
		(class _ self selectedClass) ifNotNil: [
			Browser fullOnClass: class selector: sel]].
	^ self arrowKey: aChar from: view