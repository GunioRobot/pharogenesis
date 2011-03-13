removeEmptyMessageCategories
	"Smalltalk removeEmptyMessageCategories"
	Smalltalk garbageCollect.
	ClassOrganizer allInstancesDo:
		[:org | org categories do: 
			[:cat | (org listAtCategoryNamed: cat) isEmpty
				ifTrue: [org removeCategory: cat]]]