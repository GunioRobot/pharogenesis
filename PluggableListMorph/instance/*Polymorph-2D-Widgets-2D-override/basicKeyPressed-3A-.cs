basicKeyPressed: aChar 
	| nextSelection milliSeconds slowKeyStroke  nextSelectionText oldSelection |
	nextSelection := oldSelection := self getCurrentSelectionIndex.
	milliSeconds := Time millisecondClockValue.
	slowKeyStroke := milliSeconds - lastKeystrokeTime > 500.
	lastKeystrokeTime := milliSeconds.
	slowKeyStroke
		ifTrue: ["forget previous keystrokes and search in following elements"
			lastKeystrokes := aChar asLowercase asString.]
		ifFalse: ["append quick keystrokes but don't move selection if it still matches"
			lastKeystrokes := lastKeystrokes , aChar asLowercase asString.].
	"Get rid of blanks and style used in some lists"
	nextSelectionText := self getList
		detect: [:a | a asString withBlanksTrimmed asLowercase beginsWith: lastKeystrokes]
		ifNone: [^ self ].
	"No change if model is locked"
	model okToChange ifFalse: [^ self].
	nextSelection := self getList findFirst: [:a | a = nextSelectionText].
	"The following line is a workaround around the behaviour of OBColumn>>selection:,
	 which deselects when called twice with the same argument."
	oldSelection = nextSelection ifTrue: [^ self].
	^ self changeModelSelection: nextSelection