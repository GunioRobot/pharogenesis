resizeScrollBar
	| w topLeft |
	w _ self scrollbarWidth.
	topLeft _ scrollBarOnLeft
		ifTrue: [retractableScrollBar ifTrue: [bounds topLeft - ((w-1)@0)]
									ifFalse: [bounds topLeft]]
		ifFalse: [retractableScrollBar ifTrue: [bounds topRight]
									ifFalse: [bounds topRight - ((w-1)@0)]].
	scrollBar bounds: (topLeft extent: w @ bounds height)