grow
	"Grow the elements array and reinsert the old elements"
	| oldElements |
	oldElements _ array.
	array _ Array new: array size + self growSize.
	tally _ 0.
	oldElements do:
		[:each | each == nil ifFalse: [self noCheckAdd: each]]