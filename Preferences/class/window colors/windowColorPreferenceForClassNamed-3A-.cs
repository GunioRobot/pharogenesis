windowColorPreferenceForClassNamed: aClassName
	| aColorSpec wording |
	aColorSpec _ WindowColorRegistry registeredWindowColorSpecFor: aClassName.
	wording := aColorSpec ifNil: [aClassName] ifNotNil: [aColorSpec wording].
	^(wording, 'WindowColor') asLegalSelector asSymbol.