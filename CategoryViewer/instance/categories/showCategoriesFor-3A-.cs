showCategoriesFor: aSymbol
	"Put up a pop-up list of categories in which aSymbol is filed; replace the receiver with a CategoryViewer for the one the user selects, if any"

	| allCategories aVocabulary hits meths chosen |
	aVocabulary _ self currentVocabulary.
	allCategories _ scriptedPlayer categoriesForVocabulary: aVocabulary limitClass: ProtoObject.

	hits _ allCategories select:
		[:aCategory | 
			meths _ aVocabulary allMethodsInCategory: aCategory forInstance: scriptedPlayer ofClass: scriptedPlayer class.
			meths includes: aSymbol].

	hits isEmpty ifTrue: [ ^self ].

	chosen _ (SelectionMenu selections: hits) startUp.
	chosen isEmptyOrNil ifFalse:
		[self outerViewer addCategoryViewerFor: chosen atEnd: true]

	