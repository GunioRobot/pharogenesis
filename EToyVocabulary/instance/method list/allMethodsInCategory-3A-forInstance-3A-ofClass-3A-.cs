allMethodsInCategory: aCategoryName forInstance: anObject ofClass: aClass
	"Answer a list of all methods in the etoy interface which are in the given category, on behalf of anObject, or if it is nil, aClass"

	| aCategory unfiltered suitableSelectors isAll |

	aCategoryName ifNil: [^ OrderedCollection new].
	aClass isUniClass ifTrue:
		[aCategoryName = ScriptingSystem nameForScriptsCategory ifTrue:
			[^ aClass namedTileScriptSelectors].
		aCategoryName = ScriptingSystem nameForInstanceVariablesCategory ifTrue:
			[^ aClass slotInfo keys asSortedArray collect:
				[:anInstVarName | Utilities getterSelectorFor: anInstVarName]]].
	unfiltered _ (isAll _ aCategoryName = self allCategoryName)
		ifTrue:
			[methodInterfaces collect: [:anInterface | anInterface selector]]
		ifFalse:
			[aCategory _ categories detect: [:cat | cat categoryName == aCategoryName] 
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