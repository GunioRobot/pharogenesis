drawRule: normalRule

	^ shadowDrawing ifTrue: [Form paint] ifFalse: [normalRule]