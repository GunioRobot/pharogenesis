supplementaryPartsDescriptions
	"Extra items for parts bins"

	^ {DescriptionForPartsBin
		formalName: 'Column'
		categoryList: #('Presentation')
		documentation: 'An object that presents the things within it in a column'
		globalReceiverSymbol: #AlignmentMorph
		nativitySelector: #columnPrototype.
	DescriptionForPartsBin
		formalName: 'Row'
		categoryList: #('Presentation')
		documentation: 'An object that presents the things within it in a row'
		globalReceiverSymbol: #AlignmentMorph
		nativitySelector: #rowPrototype}