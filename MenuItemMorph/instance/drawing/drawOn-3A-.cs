drawOn: aCanvas 
	| stringColor stringBounds leftEdge |
	isSelected & isEnabled
		ifTrue: [
			aCanvas fillRectangle: self bounds fillStyle: self selectionFillStyle.
			stringColor := color negated]
		ifFalse: [stringColor := color].

	leftEdge := 0.
	self hasIcon
		ifTrue: [| iconForm | 
			iconForm := isEnabled ifTrue:[self icon] ifFalse:[self icon asGrayScale].
			aCanvas paintImage: iconForm at: self left @ (self top + (self height - iconForm height // 2)).
			leftEdge := iconForm width + 2].

	self hasMarker
		ifTrue: [ leftEdge := leftEdge + self submorphBounds width + 8 ].

	stringBounds := bounds left: bounds left + leftEdge.

	aCanvas
		drawString: contents
		in: stringBounds
		font: self fontToUse
		color: stringColor.
	subMenu
		ifNotNil: [aCanvas paintImage: SubMenuMarker at: self right - 8 @ (self top + self bottom - SubMenuMarker height // 2)]