image: aForm at: aPoint sourceRect: sourceRect rule: rule
	"Draw the portion of the given Form defined by sourceRect at the given point using the given BitBlt combination rule."

	| bb |
	bb _ BitBlt destForm: port destForm
		sourceForm: aForm
		fillColor: nil
		combinationRule: rule
		destOrigin: aPoint + origin
		sourceOrigin: sourceRect origin
		extent: sourceRect extent
		clipRect: clipRect truncated.

	shadowDrawing ifTrue: [
		bb colorMap: (Color maskingMap: aForm depth).
		bb fillColor: shadowStipple.
	] ifFalse: [
		bb colorMap:
			(aForm colormapIfNeededForDepth: bb destForm depth)].

	bb copyBits.
