basicKeyPressed: aChar 
	| oldSelection nextSelection max milliSeconds nextSelectionList nextSelectionText |
	nextSelection _ oldSelection _ self getCurrentSelectionIndex.
	max _ self maximumSelection.
	milliSeconds _ Time millisecondClockValue.
	milliSeconds - lastKeystrokeTime > 300 ifTrue: ["just use the one current character for selecting"
		lastKeystrokes _ ''].
	lastKeystrokes _ lastKeystrokes , aChar asLowercase asString.
	lastKeystrokeTime _ milliSeconds.
	nextSelectionList _ OrderedCollection newFrom: (self getList copyFrom: oldSelection + 1 to: max).
	nextSelectionList addAll: (self getList copyFrom: 1 to: oldSelection).
	"Get rid of blanks and style used in some lists"
	nextSelectionText _ nextSelectionList detect: [:a | a asString withBlanksTrimmed asLowercase beginsWith: lastKeystrokes]
				ifNone: [^ self flash"match not found"].
	model okToChange ifFalse: [^ self].
	nextSelection _ self getList findFirst: [:a | a == nextSelectionText].
	"No change if model is locked"
	oldSelection == nextSelection ifTrue: [^ self flash].
	^ self changeModelSelection: nextSelection