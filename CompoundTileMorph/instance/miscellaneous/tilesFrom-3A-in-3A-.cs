tilesFrom: msgNode in: aScriptor
	"Construct an if-then from a parseTree."

	| sel |
	testPart playerScripted: aScriptor playerScripted.
	yesPart playerScripted: aScriptor playerScripted.
	noPart playerScripted: aScriptor playerScripted.
	testPart tilesFrom: msgNode receiver receiver. 	"strip off (test ~~ false)"
	sel _ msgNode selector key.
	sel == #ifTrue:ifFalse: ifTrue: [
		yesPart tilesFrom: msgNode arguments first.
		noPart tilesFrom: msgNode arguments second].
	sel == #ifTrue: ifTrue: [
		yesPart tilesFrom: msgNode arguments first].
	sel == #ifFalse: ifTrue: [
		noPart tilesFrom: msgNode arguments first].

