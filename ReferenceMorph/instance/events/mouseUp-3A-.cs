mouseUp: evt
	| aColor |
	(aColor _ self valueOfProperty: #oldColor) ifNotNil: [self color: aColor].
	(self containsPoint: evt cursorPoint)
		ifTrue: [self doButtonAction].
	super mouseUp: evt "send to evt handler if any"
