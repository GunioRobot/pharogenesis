mouseDown: evt

	| growHandleExtent growHandle |
	selectOffset _ evt cursorPoint - selectionRect topLeft.
	growHandleExtent _ 4@4.
	growHandle _ ((selectionRect bottomRight - growHandleExtent) extent: growHandleExtent).
	(growHandle containsPoint: evt cursorPoint)
		ifTrue: [selectMode _ #grow]
		ifFalse: [selectMode _ #move].
