sendContentsToPrinter
	| textToPrint printer parentWindow |
	textToPrint _ paragraph text.
	textToPrint size == 0 ifTrue: [^ self inform: 'nothing to print.'].
	printer _ TextPrinter defaultTextPrinter.
	parentWindow _ self model dependents
						detect: [:dep | dep isKindOf: SystemWindow]
						ifNone: [nil].
	parentWindow isNil
		ifTrue: [printer documentTitle: 'Untitled']
		ifFalse: [printer documentTitle: parentWindow label].
	printer printText: textToPrint.

