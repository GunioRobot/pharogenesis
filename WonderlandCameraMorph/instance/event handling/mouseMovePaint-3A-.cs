mouseMovePaint: evt 
	| newEvent |
	newEvent _ self convertEvent: evt.
	newEvent ifNil:[^self].
	newEvent getVertex ifNil:[^self].
	^self perform: palette action with: newEvent