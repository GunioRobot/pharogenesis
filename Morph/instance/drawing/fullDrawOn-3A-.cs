fullDrawOn: aCanvas
	"Draw the full Morphic structure on the given Canvas"

	self visible ifFalse: [^ self].
	(self hasProperty: #errorOnDraw) ifTrue:[^self drawErrorOn: aCanvas].
	aCanvas drawMorph: self.
	self drawSubmorphsOn:aCanvas.
	self drawDropHighlightOn: aCanvas.
	self drawMouseDownHiglightOn: aCanvas
