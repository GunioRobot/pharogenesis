basicKeyPressed: aChar 
	| oldSelection nextSelection max milliSeconds nextSelectionList nextSelectionText s|
	nextSelection := oldSelection := self getCurrentSelectionIndex.
	max := self maximumSelection.
	milliSeconds := Time millisecondClockValue.
	milliSeconds - lastKeystrokeTime > 300 ifTrue: ["just use the one current character for selecting"
		lastKeystrokes := ''].
	lastKeystrokes := lastKeystrokes , aChar asLowercase asString.
	lastKeystrokeTime := milliSeconds.
	nextSelectionList := OrderedCollection newFrom: (list copyFrom: oldSelection + 1 to: max).
	nextSelectionList addAll: (list copyFrom: 1 to: oldSelection).
	"Get rid of blanks and style used in some lists"
	nextSelectionText := nextSelectionList detect: [:a |
		s := a userString ifNil: [(a submorphs collect: [:m | m userString]) detect: [:us | us notNil] ifNone: ['']].
		s withBlanksTrimmed asLowercase beginsWith: lastKeystrokes]
				ifNone: [^ self flash"match not found"].
	model okToChange ifFalse: [^ self].
	nextSelection := list findFirst: [:a |
		s := a userString ifNil: [(a submorphs collect: [:m | m userString]) detect: [:us | us notNil] ifNone: ['']].
		a == nextSelectionText].
	"No change if model is locked"
	oldSelection == nextSelection ifTrue: [^ self flash].
	^ self changeModelSelection: nextSelection