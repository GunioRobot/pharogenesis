fullBounds
	"Overridden to clip submorph hit detection to my bounds if clipping is true."

	clipping ifFalse: [^ super fullBounds].
	^ bounds
