growTo: anInteger
	"Grow the elements array and reinsert the old elements"

	| oldElements |

	oldElements := array.
	array := WeakArray new: anInteger.
	array atAllPut: flag.
	tally := 0.
	oldElements do:
		[:each | (each == flag or: [each == nil]) ifFalse: [self noCheckAdd: each]]