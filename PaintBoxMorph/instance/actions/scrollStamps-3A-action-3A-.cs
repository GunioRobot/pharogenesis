scrollStamps: actionButton action: aSelector
	"Move the stamps over"

	aSelector == #prevStamp:
		ifTrue: [stampHolder scroll: -1]
		ifFalse: [stampHolder scroll: 1].
	actionButton state: #off.
	action == #stamp: ifTrue: ["reselect the stamp and compute the cursor"
		self stampForm 
			ifNil: [self setAction: #paint:]
			ifNotNil: [tool doButtonAction]].
		