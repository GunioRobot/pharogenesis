supplementaryPartsDescriptions
	^ {DescriptionForPartsBin
		formalName: 'RoundRect'
		categoryList: #('Graphics' 'Basic')
		documentation: 'A rectangle with rounded corners'
		globalReceiverSymbol: #RectangleMorph
		nativitySelector: #roundRectPrototype.

	DescriptionForPartsBin
		formalName: 'Gradient'
		categoryList: #('Graphics' 'Basic')
		documentation: 'A rectangle with a horizontal gradient'
		globalReceiverSymbol: #RectangleMorph
		nativitySelector: #gradientPrototype.

	DescriptionForPartsBin
		formalName: 'Gradient (slanted)'
		categoryList: #('Graphics' 'Basic')
		documentation: 'A rectangle with a diagonal gradient'
		globalReceiverSymbol: #RectangleMorph
		nativitySelector: #diagonalPrototype}