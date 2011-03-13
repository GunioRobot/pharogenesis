newMorph
	| menu subMenu catDict shortCat class |
	menu _ MenuMorph entitled: 'New Morph'.
	menu addStayUpItem.
	catDict _ Dictionary new.
	SystemOrganization categories do:
		[:cat |
		((cat beginsWith: 'Morphic-')
				and: [(#('Morphic-Menus' 'Morphic-Support') includes: cat) not])
		ifTrue:
			[shortCat _ cat copyFrom: 'Morphic-' size+1 to: cat size.
			(SystemOrganization listAtCategoryNamed: cat) do:
				[:cName | class _ Smalltalk at: cName.
				((class inheritsFrom: Morph)
					and: [class includeInNewMorphMenu])
					ifTrue:
					[(catDict includesKey: shortCat) 
					ifTrue: [(catDict at: shortCat) addLast: class]
					ifFalse: [catDict at: shortCat put: (OrderedCollection with: class)]]]]].

	catDict keys asSortedCollection do:
		[:categ |
		subMenu _ MenuMorph new.
		((catDict at: categ) asSortedCollection: [:c1 :c2 | c1 name < c2 name]) do:
			[:cl | subMenu add: cl name
					target: self
					selector: #newMorphOfClass:event:
					argument: cl].
		menu add: categ subMenu: subMenu].

	menu popUpAt: self position forHand: self.
