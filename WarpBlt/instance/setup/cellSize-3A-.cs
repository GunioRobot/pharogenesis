cellSize: s
	cellSize _ s.
	cellSize = 1 ifTrue: [^ self].
	cellSize > 3 ifTrue:
		[(self confirm:
'Do you really want to average
more than 3x3 pixels?') ifFalse: [self halt]].
	colorMap _ Color colorMapIfNeededFrom: 32 to: destForm depth.
