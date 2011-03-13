allMethodsInCategory: categoryName forInstance: anObject ofClass: aClass
	"Answer a list of all methods in the etoy interface which are in the given category, on behalf of anObject, or if it is nil, aClass"

	| aCategory unfiltered suitableSelectors isAll |
	categoryName ifNil: [^ OrderedCollection new].
	aClass isUniClass ifTrue:
		[categoryName == #scripts ifTrue:
			[^ aClass namedTileScriptSelectors].
		categoryName == #'instance variables' ifTrue:
			[^ aClass slotInfo keys asSortedArray collect:
				[:anInstVarName | Utilities getterSelectorFor: anInstVarName]]].
	unfiltered _ (isAll _ categoryName = self allCategoryName)
		ifTrue:
			[methodInterfaces collect: [:anInterface | anInterface selector]]
		ifFalse:
			[aCategory _ categories detect: [:cat | cat categoryName == categoryName asSymbol] 
							ifNone: [^ OrderedCollection new].
			aCategory elementsInOrder collect: [:anElement | anElement selector]].

	(anObject isKindOf: Player) ifTrue:
		[suitableSelectors _ anObject costume selectorsForViewer.
		unfiltered _ unfiltered  select:
			[:aSelector | suitableSelectors includes: aSelector]].
	(isAll and: [aClass isUniClass]) ifTrue:
		[unfiltered addAll: aClass namedTileScriptSelectors.
		unfiltered addAll: (aClass slotInfo keys asSortedArray collect:
			[:anInstVarName | Utilities getterSelectorFor: anInstVarName])].

	^ (unfiltered copyWithoutAll: #(dummy unused)) asSortedArray