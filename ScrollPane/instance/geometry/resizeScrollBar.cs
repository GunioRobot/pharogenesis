resizeScrollBar
	| d | d _ retractableScrollBar ifTrue: [14@0] ifFalse: [0@0].
	scrollBar bounds: (scrollBarOnLeft
		ifTrue: [bounds topLeft - d extent: 16 @ bounds height]
		ifFalse: [bounds topRight - (16@0) + d extent: 16 @ bounds height])