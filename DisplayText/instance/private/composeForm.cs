composeForm
	| form1 |
	Smalltalk isMorphic
		ifTrue:
			[form1 _ (TextMorph new contentsAsIs: text) imageFormDepth: 1.
			form _ (ColorForm extent: form1 extent)
				offset: offset;
				colors: (Array
					with: (backColor == nil ifTrue: [Color transparent] ifFalse: [backColor])
					with: (foreColor == nil ifTrue: [Color black] ifFalse: [foreColor])).
			form1 displayOn: form]
		ifFalse: [form _ self asParagraph asForm]