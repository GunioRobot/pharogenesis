shiftedForGrab: aMorph
	"Support for e-toys; grab the given morph by its bottom-left corner."

	aMorph position: self primaryHand position - (0 @ aMorph fullBounds height).
	^ aMorph
