sendContentsToPrinter
	| textToPrint printer parentWindow |
	textToPrint := paragraph text.
	textToPrint size == 0 ifTrue: [^self inform: 'nothing to print.'].
	printer := TextPrinter defaultTextPrinter.
	parentWindow := self model dependents 
				detect: [:dep | dep isSystemWindow]
				ifNone: [nil].
	parentWindow isNil 
		ifTrue: [printer documentTitle: 'Untitled']
		ifFalse: [printer documentTitle: parentWindow label].
	printer printText: textToPrint