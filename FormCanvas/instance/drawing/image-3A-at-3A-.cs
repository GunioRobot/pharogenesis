image: aForm at: aPoint
	"Draw the given Form, which is assumed to be a Form following the convention that zero is the transparent pixel value."

	| bb |
	bb _ BitBlt destForm: port destForm
		sourceForm: aForm
		fillColor: nil
		combinationRule: Form paint
		destOrigin: aPoint + origin
		sourceOrigin: 0@0
		extent: aForm extent
		clipRect: clipRect truncated.

	shadowDrawing ifTrue: [
		bb colorMap: (Color maskingMap: aForm depth).
		bb fillColor: shadowStipple.
	] ifFalse: [
		bb colorMap:
			(aForm colormapIfNeededForDepth: bb destForm depth)].

	bb copyBits.
