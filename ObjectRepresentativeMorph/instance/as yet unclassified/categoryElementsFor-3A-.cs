categoryElementsFor: aCategorySymbol
	"Answer a list of tuples that characterize the elements in the given category.  Every class in the receiver's superclass chain which implements #additionsToViewerCategories is given the chance to add elements to the category"

	| aList org |
	org _  objectRepresented class organization.
	aList _ (org listAtCategoryNamed: aCategorySymbol) select:
		[:anElement | anElement numArgs < 2].
	^ aList collect:
		[:sel | 
			sel numArgs == 0
				ifTrue:
					[Array with: #command with: sel with: 'help here later']
				ifFalse:
					[Array with: #command with: sel with: 'help here later' with: #string]]