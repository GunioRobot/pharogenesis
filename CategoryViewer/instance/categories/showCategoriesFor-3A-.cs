showCategoriesFor: aSymbol
	"Put up a pop-up list of categories in which aSymbol is filed; replace the receiver with a CategoryViewer for the one the user selects, if any"

	| allCategories aVocabulary hits meths chosen |
	aVocabulary := self currentVocabulary.
	allCategories := scriptedPlayer categoriesForVocabulary: aVocabulary limitClass: ProtoObject.

	hits := allCategories select:
		[:aCategory | 
			meths := aVocabulary allMethodsInCategory: aCategory forInstance: scriptedPlayer ofClass: scriptedPlayer class.
			meths includes: aSymbol].

	hits isEmpty ifTrue: [ ^self ].

	chosen := (SelectionMenu selections: hits) startUp.
	chosen isEmptyOrNil ifFalse:
		[self outerViewer addCategoryViewerFor: chosen atEnd: true]

	