grow
	"Grow the elements array and reinsert the old elements"
	| oldElements |
	oldElements := array.
	array := Array new: array size + self growSize.
	tally := 0.
	oldElements do:
		[:each | each == nil ifFalse: [self noCheckAdd: each]]