chooseMorphInCategory: category
	| menu class |
	menu _ CustomMenu new.
	(SystemOrganization listAtCategoryNamed: category)
		do: [:c | class _ Smalltalk at: c.
			((class inheritsFrom: Morph) and: [class
includeInNewMorphMenu]) ifTrue:
				[menu add: class name action: class]].
	menu addLine.
	menu add: 'categories...' action: #chooseMorphicCategory.
	^ menu startUp

"HandMorph new chooseMorphInCategory: 'Morphic-Kernel' asSymbol"

