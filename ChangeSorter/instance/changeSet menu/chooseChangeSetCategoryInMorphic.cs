chooseChangeSetCategoryInMorphic
	"Present the user with a list of change-set-categories and let her choose one.  In this morphic variant, we include balloon help"

	|  aMenu |
	aMenu := MenuMorph new defaultTarget: self.
	aMenu title: 
'Choose the category of
change sets to show in
this Change Sorter
(red = current choice)'.
	self changeSetCategories elementsInOrder do:
		[:aCategory |
			aMenu add: aCategory categoryName target: self selector: #showChangeSetCategory: argument: aCategory.
			aCategory == changeSetCategory ifTrue:
				[aMenu lastItem color: Color red].
			aMenu balloonTextForLastItem: aCategory documentation].
	aMenu popUpInWorld