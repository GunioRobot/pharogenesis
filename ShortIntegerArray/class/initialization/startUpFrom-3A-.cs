startUpFrom: anImageSegment
	"In this case, do we need to swap word halves when reading this segement?"

	^ (SmalltalkImage current  endianness) ~~ (anImageSegment endianness)
			ifTrue: [Message selector: #swapShortObjects]		"will be run on each instance"
			ifFalse: [nil].
