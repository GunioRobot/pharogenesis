supplementaryPartsDescriptions
	^ {
	DescriptionForPartsBin
		formalName: 'Text (border)'
		categoryList: #('Text')
		documentation: 'A text field with border'
		globalReceiverSymbol: #TextMorph
		nativitySelector: #borderedPrototype.

"	DescriptionForPartsBin
		formalName: 'Text (fancy)'
		categoryList: #('Text')
		documentation: 'A text field with a rounded shadowed border, with a fancy font.'
		globalReceiverSymbol: #TextMorph
		nativitySelector: #fancyPrototype."

	DescriptionForPartsBin
		formalName: 'Text'
		categoryList: #('Basic' 'Text')
		documentation: 'A raw piece of text which you can edit into anything you want'
		globalReceiverSymbol: #TextMorph
		nativitySelector: #boldAuthoringPrototype.
}
