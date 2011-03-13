getPatchBrightnessAtX: x y: y
	"Answer the brightness of the patch at the given location, a number from 0 to 100."

	| c |
	c := self getPatchColorAtX: x y: y.
	^ (c brightness * 100.0) rounded
