drawOn: aCanvas 
	| dotBounds size alphaCanvas dotSize |
	super drawOn: aCanvas.
	self class showSplitterHandles ifTrue: [
	size _ self splitsTopAndBottom
				ifTrue: [self handleSize transposed]
				ifFalse: [self handleSize].
	dotSize _ self splitsTopAndBottom
				ifTrue: [6 @ self class splitterWidth]
				ifFalse: [self class splitterWidth @ 6].
	alphaCanvas _ aCanvas asAlphaBlendingCanvas: 0.7.
	dotBounds _ Rectangle center: self bounds center extent: size.
	alphaCanvas fillRectangle: dotBounds color: self handleColor.
	dotBounds _ Rectangle center: self bounds center extent: dotSize.
	alphaCanvas fillRectangle: dotBounds color: self dotColor]