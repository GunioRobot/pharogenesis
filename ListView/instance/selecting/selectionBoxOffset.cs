selectionBoxOffset
	"Answer an integer that determines the y position for the display box of 
	the current selection."

	^ (selection - 1 + (topDelimiter == nil ifTrue: [0] ifFalse: [1]))
		* list lineGrid