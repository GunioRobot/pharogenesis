updateVisualState: evt
	
"	oldColor ifNil: [^self].

	self color: 
		((self containsPoint: evt cursorPoint)
			ifTrue: [oldColor mixed: 1/2 with: Color white]
			ifFalse: [oldColor])"