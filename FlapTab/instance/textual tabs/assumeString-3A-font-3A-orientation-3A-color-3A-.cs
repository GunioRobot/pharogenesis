assumeString: aString font: aFont orientation: anOrientation color: aColor
	| aTextMorph workString pad |
	pad _ (anOrientation == #vertical) 
		ifTrue:	[Character cr]
		ifFalse:	[$ ].
	workString _ pad asString.
	aString do:
		[:ch |
			workString _ workString copyWith: ch.
			workString _ workString copyWith: pad].
	(anOrientation == #vertical)
		ifTrue:
			[workString _ workString copyFrom: 2 to: workString size - 1].

	aTextMorph _ (TextMorph new beAllFont: aFont) width: 10; contents: workString; yourself.
	self removeAllMorphs.
	self addMorph: aTextMorph centered.
	aTextMorph lock.
	anOrientation == #horizontal
		ifTrue:
			[self borderWidth: 0]
		ifFalse:
			[self borderWidth: 3; borderColor: #raised].
	self fitContents.
	aColor ifNotNil: [self color: aColor].
	aTextMorph position: self position.
	self layoutChanged