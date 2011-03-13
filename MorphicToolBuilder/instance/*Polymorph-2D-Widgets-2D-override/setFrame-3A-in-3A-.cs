setFrame: aRectangle in: widget
	"Updated to recognize real layout frames for flexibility."
	
	| frame |
	aRectangle ifNil: [^nil].
	frame := aRectangle isRectangle
		ifTrue: [self asFrame: aRectangle]
		ifFalse: [aRectangle]. "assume LayoutFrame"
	widget layoutFrame: frame.
	widget hResizing: #spaceFill; vResizing: #spaceFill.
	(parent isSystemWindow) ifTrue:[
		widget borderWidth: 2; borderColor: #inset]