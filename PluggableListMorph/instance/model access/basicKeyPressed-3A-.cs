basicKeyPressed: aChar 
	| oldSelection nextSelection max milliSeconds slowKeyStroke nextSelectionList nextSelectionText |
	nextSelection := oldSelection := self getCurrentSelectionIndex.
	max := self maximumSelection.
	milliSeconds := Time millisecondClockValue.
	slowKeyStroke := milliSeconds - lastKeystrokeTime > 300.
	lastKeystrokeTime := milliSeconds.
	nextSelectionList := OrderedCollection newFrom: (self getList copyFrom: oldSelection + 1 to: max).
	nextSelectionList addAll: (self getList copyFrom: 1 to: ((oldSelection - 1) max: 0)).
	slowKeyStroke
		ifTrue: ["forget previous keystrokes and search in following elements"
			lastKeystrokes := aChar asLowercase asString.
			oldSelection > 0 ifTrue: [nextSelectionList addLast: (self getList at: oldSelection)]]
		ifFalse: ["append quick keystrokes but don't move selection if it still matches"
			lastKeystrokes := lastKeystrokes , aChar asLowercase asString.
			oldSelection > 0 ifTrue: [nextSelectionList addFirst: (self getList at: oldSelection)]].
	"Get rid of blanks and style used in some lists"
	nextSelectionText := nextSelectionList
		detect: [:a | a asString withBlanksTrimmed asLowercase beginsWith: lastKeystrokes]
		ifNone: [^ self flash "match not found"].
	"No change if model is locked"
	model okToChange ifFalse: [^ self].
	nextSelection := self getList findFirst: [:a | a = nextSelectionText].
	oldSelection == nextSelection ifTrue: [^ self flash].
	^ self changeModelSelection: nextSelection