newMorph
	| morphClassList menu subMenu catDict cat |
	menu _ MenuMorph new.
	menu addStayUpItem.
	menu addTitle: 'Select Morph Class'.
	morphClassList _ Morph withAllSubclasses
			select: [:cl | cl includeInNewMorphMenu].
	catDict _ Dictionary new.
	morphClassList do:
		[:cl | cat _ cl category.
		(cat beginsWith: 'Morphic-') ifTrue:
			[cat _ cat copyFrom: 'Morphic-' size+1 to: cat size].
		(catDict includesKey: cat) 
		ifTrue: [(catDict at: cat) addLast: cl]
		ifFalse: [catDict at: cat put: (OrderedCollection with: cl)]].
	catDict removeKey: 'Menus';
		 removeKey: 'Support'.
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
