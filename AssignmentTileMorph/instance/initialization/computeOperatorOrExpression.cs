computeOperatorOrExpression
	"Compute the operator or expression to use, and set the wording correectly on the tile face"

	| aSuffix wording anInterface getter doc |
	operatorOrExpression _ (assignmentRoot, assignmentSuffix) asSymbol.
	aSuffix _ self currentVocabulary translatedWordingFor:  assignmentSuffix.
	getter _ Utilities getterSelectorFor: assignmentRoot.
	anInterface _ self currentVocabulary methodInterfaceAt: getter ifAbsent: [Vocabulary eToyVocabulary methodInterfaceAt: getter ifAbsent: [nil]].
	wording _ anInterface ifNotNil: [anInterface wording] ifNil: [assignmentRoot copyWithout: $:].
	(anInterface notNil and: [(doc _ anInterface documentation) notNil])
		ifTrue:
			[self setBalloonText: doc].
	operatorReadoutString _ wording translated, ' ', aSuffix.
 	self line1: operatorReadoutString.
	self addArrowsIfAppropriate