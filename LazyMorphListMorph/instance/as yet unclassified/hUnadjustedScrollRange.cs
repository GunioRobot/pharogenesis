hUnadjustedScrollRange
	"Answer the width of the widest item."

	maxWidth ifNotNil:[^maxWidth].
	listItems isEmpty ifTrue: [^0].
	maxWidth := 0.
	listItems do: [:each |
		each ifNotNil: [maxWidth := maxWidth max: (self widthToDisplayItem: each)]].
	^maxWidth
