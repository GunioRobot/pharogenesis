singleImageFromUser
	"Let the user paint a single image, and return an array consisting of the form and its bounding box.  "

	| result |
	ticksToDwell _ 1.
	result _ self getPaintingStartingWith: nil at: nil.
	^ self deliverPainting: result