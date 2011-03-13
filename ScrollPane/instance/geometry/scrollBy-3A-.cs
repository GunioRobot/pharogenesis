scrollBy: delta
	"Move the contents in the direction delta."
	"For now, delta is assumed to have a zero x-component"
	| newYoffset |
	newYoffset _ scroller offset y - delta y max: 0.
	scroller offset: scroller offset x @ newYoffset.
	scrollBar value: (newYoffset asFloat / self totalScrollRange)