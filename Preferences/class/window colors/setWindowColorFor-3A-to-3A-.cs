setWindowColorFor: modelSymbol to: incomingColor
	| aColor |
	(Parameters includesKey: #windowColors) ifFalse:
		[Parameters at: #windowColors put: IdentityDictionary new.
		self installBrightWindowColors].
	aColor _ incomingColor asNontranslucentColor.
	(aColor = ColorPickerMorph perniciousBorderColor or: [aColor = Color black]) ifTrue: [^ self].
	^ (Parameters at: #windowColors) at: modelSymbol put: aColor
	