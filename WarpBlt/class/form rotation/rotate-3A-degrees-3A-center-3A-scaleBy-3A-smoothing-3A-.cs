rotate: srcForm degrees: angleInDegrees center: aPoint scaleBy: scalePoint smoothing: cellSize
	"Rotate the given Form the given number of degrees about the given center and scale its width and height by x and y of the given scale point. Smooth using the given cell size, an integer between 1 and 3, where 1 means no smoothing. Return a pair where the first element is the rotated Form and the second is the position offset required to align the center of the rotated Form with that of the original. Note that the dimensions of the resulting Form generally differ from those of the original."

	| srcRect center radians dstOrigin dstCorner p dstRect inverseScale quad dstForm newCenter warpSrc |
	srcRect _ srcForm boundingBox.
	center _ srcRect center.
	radians _ angleInDegrees degreesToRadians.
	dstOrigin _ dstCorner _ center.
	srcRect corners do: [:corner |
		"find the limits of a rectangle that just encloses the rotated
		 original; in general, this rectangle will be larger than the
		 original (e.g., consider a square rotated by 45 degrees)"
		p _ ((corner - center) scaleBy: scalePoint) + center.
		p _ (p rotateBy: radians about: center) rounded.
		dstOrigin _ dstOrigin min: p.
		dstCorner _ dstCorner max: p].

	"rotate the enclosing rectangle back to get the source quadrilateral"
	dstRect _ dstOrigin corner: dstCorner.
	inverseScale _ (1.0 / scalePoint x)@(1.0 / scalePoint y).
	quad _ dstRect innerCorners collect: [:corner |
		p _ corner rotateBy: radians negated about: center.
		((p - center) scaleBy: inverseScale) + center].

	"make a Form to hold the result and do the rotation"
	warpSrc _ srcForm.
	(srcForm isKindOf: ColorForm)
		ifTrue: [
			cellSize > 1
				ifTrue: [
					warpSrc _ Form extent: srcForm extent depth: 16.
					srcForm displayOn: warpSrc.
					dstForm _ Form extent: dstRect extent depth: 16]  "use 16-bit depth to allow smoothing"
				ifFalse: [
					dstForm _ srcForm class extent: dstRect extent depth: srcForm depth]]
		ifFalse: [
			dstForm _ srcForm class extent: dstRect extent depth: srcForm depth].

	(WarpBlt toForm: dstForm)
		sourceForm: warpSrc;
		colorMap: (dstForm colormapIfNeededForDepth: warpSrc depth);
		cellSize: cellSize;  "installs a new colormap if cellSize > 1"
		combinationRule: Form paint;
		copyQuad: quad toRect: dstForm boundingBox.

	(dstForm isKindOf: ColorForm) ifTrue: [dstForm colors: srcForm colors copy].
	newCenter _ (center rotateBy: radians about: aPoint) truncated.
	^ Array with: dstForm with: dstRect origin + (newCenter - center)
