layoutChanged
	"Update rotatedForm and offsetWhenRotated and compute new bounds."

	| unrotatedOrigin |
	self changed.
	unrotatedOrigin _ bounds origin - offsetWhenRotated.
	(rotationStyle == #none and: [scalePoint = (1.0@1.0)])
		ifTrue: [
			"zero rotation and scale; use original Form.
			All normal rotation handled by TransformMorph.rotationDegrees:"
			rotatedForm _ originalForm.
			offsetWhenRotated _ 0@0]
		ifFalse: [self generateRotatedForm].	"changes offsetWhenRotated"

	bounds _ (unrotatedOrigin + offsetWhenRotated) extent: rotatedForm extent.
	super layoutChanged.
	self changed.
