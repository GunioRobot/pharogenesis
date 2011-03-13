factoredCategories
	| prefsWithoutInits extraItem |
	"Preferences factoredCategories"
	"CategoryInfo _ nil"

	CategoryInfo ifNil:
		[CategoryInfo _ self initialCategoryInfo].
	((prefsWithoutInits _ self preferencesLackingInitializers) size > 0)
		ifTrue:
			[extraItem _ (Array with: 'uncategorized' with: prefsWithoutInits asSortedArray)].
	^ (extraItem
		ifNil:
			[CategoryInfo]
		ifNotNil:
			[CategoryInfo, (Array with: extraItem)]) copyWith: {'search results'. OrderedCollection new}