removeEmptyMessageCategories
	"Smalltalk removeEmptyMessageCategories"
	Smalltalk garbageCollect.
	ClassOrganizer allInstances , (Array with: SystemOrganization) do:
		[:org | org categories do: 
			[:cat | (org listAtCategoryNamed: cat) isEmpty
				ifTrue: [org removeCategory: cat]]]