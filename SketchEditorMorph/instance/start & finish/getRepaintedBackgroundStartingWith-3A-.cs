getRepaintedBackgroundStartingWith: startingForm
	"Obtain a revised background painting from the user, given that the point of departure is startingForm, to be displayed in aRectangle."

	| result |
	result _ self getPaintingStartingWith: startingForm at: canvasRectangle.
	^ self deliverPainting: result
	"Caller will want to fetch (aSketchEditorMorph painting) to get one that has not been trimmed"