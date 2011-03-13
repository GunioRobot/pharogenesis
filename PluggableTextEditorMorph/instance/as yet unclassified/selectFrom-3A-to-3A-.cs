selectFrom: start to: stop
	"Tell my textMorph's editor to select the given range."

	self textMorph editor selectFrom: start to: stop.
	^selectionInterval := self textMorph editor selectionInterval