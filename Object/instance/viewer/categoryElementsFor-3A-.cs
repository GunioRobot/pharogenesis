categoryElementsFor: aCategorySymbol
	"Just a start.  Answer a list of tuples that characterize the elements in the given category.  Every class in the receiver's superclass chain which implements #additionsToViewerCategories is given the chance to add elements to the category.  In this first version, only methods with 0 or 1 arguments are included, because of the limitations of PhraseTileMorphs.  Later, the entire method vocabulary of a category will be incorporated, and we will use type hints for the arguments, and we will support a way that methods with return-value types can have type-appropriate readouts for their values, etc."

	| aList org |
	org _  self class organization.
	aList _ (org listAtCategoryNamed: aCategorySymbol) select:
		[:anElement | anElement numArgs < 2].
	^ aList collect:
		[:sel | 
			sel numArgs == 0
				ifTrue:
					[Array with: #command with: sel with: 'help here later']
				ifFalse:
					[Array with: #command with: sel with: 'help here later' with: #string]]