specialKeyPressed: asciiValue
	"A special key with the given ascii-value was pressed; dispatch it"

	| oldSelection nextSelection max howManyItemsShowing |
	asciiValue = 27 ifTrue: 
		[" escape key"
		^ ActiveEvent shiftPressed
			ifTrue:
				[ActiveWorld putUpWorldMenuFromEscapeKey]
			ifFalse:
				[self yellowButtonActivity: false]].

	max _ self maximumSelection.
	max > 0 ifFalse: [^ self].
	nextSelection _ oldSelection _ self getCurrentSelectionIndex.
	asciiValue = 31 ifTrue: 
		[" down arrow"
		nextSelection _ oldSelection + 1.
		nextSelection > max ifTrue: [nextSelection _ 1]].
	asciiValue = 30 ifTrue: 
		[" up arrow"
		nextSelection _ oldSelection - 1.
		nextSelection < 1 ifTrue: [nextSelection _ max]].
	asciiValue = 1 ifTrue:
		[" home"
		nextSelection _ 1].
	asciiValue = 4 ifTrue:
		[" end"
		nextSelection _ max].
	howManyItemsShowing _ self numSelectionsInView.
	asciiValue = 11 ifTrue:
		[" page up"
		nextSelection _ 1 max: oldSelection - howManyItemsShowing].
	asciiValue = 12 ifTrue:
		[" page down"
		nextSelection _ oldSelection + howManyItemsShowing min: max].
	model okToChange ifFalse: [^ self].
	"No change if model is locked"
	oldSelection = nextSelection ifTrue: [^ self flash].
	^ self changeModelSelection: nextSelection