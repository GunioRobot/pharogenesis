drawOn: aCanvas
	| selectionColor |
	isSelected & isEnabled
		ifTrue:
			[selectionColor _ Display depth <= 2
				ifTrue: [Color gray]
				ifFalse: [owner color darker].
			aCanvas fillRectangle: self bounds color: selectionColor].
	super drawOn: aCanvas.
	subMenu ifNotNil:
		[aCanvas
			paintImage: SubMenuMarker
			at: self right - 8 @ (self top + self bottom - SubMenuMarker height // 2)]