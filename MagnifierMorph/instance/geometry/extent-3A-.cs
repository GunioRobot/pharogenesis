extent: aPoint
	"Round to multiples of magnification"
	srcExtent _ (aPoint - (2 * borderWidth)) // magnification.
	^super extent: self defaultExtent