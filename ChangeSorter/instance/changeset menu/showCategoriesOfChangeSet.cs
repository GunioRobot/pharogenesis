showCategoriesOfChangeSet
	"Show a list of all the categories in which the selected change-set occurs
	at the moment. Install the one the user chooses, if any."
	| aMenu |
	aMenu := MenuMorph new defaultTarget: self.
	aMenu title: 'Categories which
contain change set
"' , myChangeSet name , '"'.
	self changeSetCategories elementsInOrder
		do: [:aCategory | 
			(aCategory includesChangeSet: myChangeSet)
				ifTrue: [aMenu
						add: aCategory categoryName
						target: self
						selector: #showChangeSetCategory:
						argument: aCategory.
					aCategory == changeSetCategory
						ifTrue: [aMenu lastItem color: Color red]].
			aMenu balloonTextForLastItem: aCategory documentation].
	aMenu popUpInWorld