scrollBy: delta
	"Move the contents in the direction delta."
	"For now, delta is assumed to have a zero x-component"
	| newYoffset r |
	newYoffset _ scroller offset y - delta y max: 0.
	scroller offset: scroller offset x @ newYoffset.
	(r _ self leftoverScrollRange) = 0
		ifTrue: [scrollBar value: 0.0]
		ifFalse: [scrollBar value: newYoffset asFloat / r]