hasVideo
	"Answer true if I have one or more frames."

	^ frameOffsets size > 1  "note: the empty movie still has one frameOffset"
