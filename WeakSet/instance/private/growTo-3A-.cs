growTo: anInteger
	"Grow the elements array and reinsert the old elements"

	| oldElements |

	oldElements _ array.
	array _ WeakArray new: anInteger.
	array atAllPut: flag.
	tally _ 0.
	oldElements do:
		[:each | (each == flag or: [each == nil]) ifFalse: [self noCheckAdd: each]]