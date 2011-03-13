drawOn: aCanvas
	| colorToFillWith areaToFill next |

	super drawOn: aCanvas.
	selectedMorph ifNil: [^self].
	colorToFillWith _ color.
	next _ self.
	[colorToFillWith isTransparent and: [(next _ next owner) notNil]] whileTrue: [
		colorToFillWith _ next color.
	].
	colorToFillWith _ colorToFillWith luminance < 0.5 ifTrue: [
		colorToFillWith muchLighter
	] ifFalse: [
		colorToFillWith darker
	].

	areaToFill _ ((scroller transformFrom: self) localBoundsToGlobal: selectedMorph bounds)
					intersect: scroller bounds.
	aCanvas fillRectangle: areaToFill color: colorToFillWith.
