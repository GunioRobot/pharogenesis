borderStyleForSymbol: aStyleSymbol
	"Answer a suitable BorderStyle for me of the type represented by a given symbol"

	| aStyle existing |
	aStyle _ BorderStyle borderStyleForSymbol: aStyleSymbol asSymbol.
	aStyle ifNil: [self error: 'bad style'].
	existing _ self borderStyle.
	aStyle width: existing width;
		baseColor: existing baseColor.
	^ (self canDrawBorder: aStyle)
		ifTrue:
			[aStyle]
		ifFalse:
			[nil]