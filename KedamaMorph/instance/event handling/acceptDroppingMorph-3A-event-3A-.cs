acceptDroppingMorph: morphToDrop event: evt

	| f turtle |
	(morphToDrop renderedMorph isKindOf: SketchMorph) ifFalse: [
		^morphToDrop rejectDropMorphEvent: evt.
	].

	f _ morphToDrop renderedMorph rotatedForm.
	f _ f magnify: f boundingBox by: (1.0 / self pixelsPerPatch asFloat) smoothing: 1.

	turtle _ self player newTurtleSilently.
	turtle createTurtlesAsIn: f originAt: ((morphToDrop topLeft - self topLeft) / self pixelsPerPatch asFloat) asIntegerPoint.
	"turtle isGroup: true."
	turtle color: (self dominantColorWithoutTransparent: f).
