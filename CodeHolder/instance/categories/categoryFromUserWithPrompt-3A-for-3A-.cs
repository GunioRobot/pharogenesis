categoryFromUserWithPrompt: aPrompt for: aClass
	"self new categoryFromUserWithPrompt: 'testing' for: SystemDictionary"

	|  labels myCategories reject lines cats newName menuIndex |
	labels _ OrderedCollection with: 'new...'.
	labels addAll: (myCategories _ aClass organization categories asSortedCollection:
		[:a :b | a asLowercase < b asLowercase]).
	reject _ myCategories asSet.
	reject
		add: ClassOrganizer nullCategory;
		add: ClassOrganizer default.
	lines _ OrderedCollection with: 1 with: (myCategories size + 1).

	aClass allSuperclasses do:
		[:cls |
			cats _ cls organization categories reject:
				 [:cat | reject includes: cat].
			cats isEmpty ifFalse:
				[lines add: labels size.
				labels addAll: (cats asSortedCollection:
					[:a :b | a asLowercase < b asLowercase]).
				reject addAll: cats]].

	newName _ (labels size = 1 or:
		[menuIndex _ (PopUpMenu labelArray: labels lines: lines)
		startUpWithCaption: aPrompt.
		menuIndex = 0 ifTrue: [^ nil].
		menuIndex = 1])
			ifTrue:
				[FillInTheBlank request: 'Please type new category name'
					initialAnswer: 'category name']
			ifFalse: 
				[labels at: menuIndex].
	^ newName ifNotNil: [newName asSymbol]