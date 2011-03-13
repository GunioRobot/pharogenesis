resizeScrollBar
	| w topLeft |
	w _ self scrollbarWidth.
	topLeft _ scrollBarOnLeft
		ifTrue: [retractableScrollBar ifTrue: [bounds topLeft - (w-borderWidth@0)]
									ifFalse: [bounds topLeft + (borderWidth-1@0)]]
		ifFalse: [retractableScrollBar ifTrue: [bounds topRight - (borderWidth@0)]
									ifFalse: [bounds topRight - (w+borderWidth-1@0)]].
	scrollBar bounds: (topLeft extent: w @ bounds height)