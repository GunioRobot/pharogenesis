newMorph
	"The user requested 'new morph' from the world menu.  Put up a menu that allows many ways of obtaining new morphs.  If the preference #classicNewMorphMenu is true, the full form of yore is used; otherwise, a much shortened form is used."

	| menu subMenu catDict shortCat class |

	menu _ self menu: 'Add a new morph'.
	menu 
		add: 'from paste buffer' translated target: myHand action: #pasteMorph;
		add: 'from alphabetical list' translated subMenu: self alphabeticalMorphMenu;
		add: 'from a file...' translated target: self action: #readMorphFromAFile.
	menu addLine.
	menu add: 'grab rectangle from screen' translated target: myWorld action: #grabDrawingFromScreen:;
		add: 'grab with lasso from screen' translated target: myWorld action: #grabLassoFromScreen:;
		add: 'grab rubber band from screen' translated target: myWorld action: #grabRubberBandFromScreen:;
		add: 'grab flood area from screen' translated target: myWorld action: #grabFloodFromScreen:.
	menu addLine.
	menu add: 'make new drawing' translated target: myWorld action: #newDrawingFromMenu:;
		add: 'make link to project...' translated target: self action: #projectThumbnail.

	Preferences classicNewMorphMenu ifTrue:
		[menu addLine.

		catDict _ Dictionary new.
		SystemOrganization categories do:
			[:cat |
			((cat beginsWith: 'Morphic-')
					and: [(#('Morphic-Menus' 'Morphic-Support') includes: cat) not])
			ifTrue:
				[shortCat _ (cat copyFrom: 'Morphic-' size+1 to: cat size) translated.
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
			menu add: categ subMenu: subMenu]].

	self doPopUp: menu.
