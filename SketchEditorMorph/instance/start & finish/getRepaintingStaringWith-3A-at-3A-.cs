getRepaintingStaringWith: startingForm at: aRectangle
	"Obtain a revised painting from the user, given that the point of departure is startingForm, to be displayed at aRectangle.
	: accept the new graphic even if no fresh paint laid down, so other edits can stick."

	| result |
	result _ self getPaintingStartingWith: startingForm at: aRectangle.
	^ self deliverPainting: result