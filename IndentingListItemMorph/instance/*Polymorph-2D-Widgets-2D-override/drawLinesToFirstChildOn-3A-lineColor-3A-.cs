drawLinesToFirstChildOn: aCanvas lineColor: lineColor 
	"Draw line from me to first child.
	Don't bother if the first child has a toggle.."

	| vLineX vLineTop vLineBottom childBounds childCenter myTheme|
	self firstChild hasToggle ifTrue: [^self].
	childBounds := self firstChild toggleBounds.
	childCenter := childBounds center.
	vLineX := childCenter x.
	vLineTop := bounds bottom.
	self firstChild hasToggle
		ifTrue: [vLineBottom := childCenter y - (childBounds height // 2) + 1]
		ifFalse: [vLineBottom := childCenter y - 2].
	myTheme := self theme.
	aCanvas
		frameRectangle: (vLineX @ vLineTop corner: vLineX + 1 @ vLineBottom)
		width: myTheme treeLineWidth
		colors: (myTheme treeLineColorsFrom: lineColor)
		dashes: myTheme treeLineDashes