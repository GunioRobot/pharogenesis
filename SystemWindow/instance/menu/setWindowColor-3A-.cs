setWindowColor: incomingColor
	| existingColor aColor |
	incomingColor ifNil: [^ self].  "it happens"
	aColor _ incomingColor asNontranslucentColor.
	(aColor = ColorPickerMorph perniciousBorderColor 
		or: [aColor = Color black]) ifTrue: [^ self].
	existingColor _ self paneColorToUse.
	existingColor ifNil: [^ self beep].
	(self allMorphs copyWithout: self) do:
		[:aMorph |
			((aMorph isKindOf: PluggableButtonMorph) and: [aMorph offColor = existingColor])
				ifTrue:
					[aMorph onColor: aColor darker offColor: aColor].
			aMorph color = existingColor
				ifTrue:
					[aMorph color: aColor]].
	self setStripeColorsFrom: aColor
		
