setWindowColor: incomingColor
	| existingColor aColor |

	incomingColor ifNil: [^ self].  "it happens"
	aColor _ incomingColor asNontranslucentColor.
	(aColor = ColorPickerMorph perniciousBorderColor 
		or: [aColor = Color black]) ifTrue: [^ self].
	existingColor _ self paneColorToUse.
	existingColor ifNil: [^ self beep].
	self setStripeColorsFrom: aColor
		
