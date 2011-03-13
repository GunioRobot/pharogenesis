initializeFromEToyCommandSpec: tuple category: aCategorySymbol
	"tuple holds an old etoy command-item spec, of the form found in #additionsToViewerCategories methods.   Initialize the receiver to hold the same information"

	selector _ tuple second.
	self documentation: tuple third.
	aCategorySymbol ifNotNil: [self flagAttribute: aCategorySymbol].
	tuple size > 3 ifTrue:
		[argumentSpecifications _ OrderedCollection with:
			(Variable new variableType: tuple fourth)]
	