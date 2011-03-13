initialize
	"Initialize the receiver (automatically called when instances are created via 'new')"

	|   classes aMethodCategory selectors categorySymbols |
	super initialize.
	self vocabularyName: #eToy.
	self documentation: '"EToy" is a vocabulary that provides the equivalent of the 1997-2000 etoy prototype'.
	categorySymbols _ Set new.
	classes _ Smalltalk allImplementorsOf: #additionsToViewerCategories.
	classes do:
		[:anItem |
		MessageSet parse: anItem toClassAndSelector:
			[:aClass :aSelector | aClass].
		categorySymbols addAll: aClass soleInstance basicNew categoriesForViewer].

	categorySymbols asOrderedCollection do:
		[:aCategorySymbol |
			aMethodCategory _ ElementCategory new categoryName: aCategorySymbol.
				classes _ (Smalltalk allImplementorsOf: #additionsToViewerCategories) collect:
					[:anItem | MessageSet parse: anItem toClassAndSelector: [:aMetaClass :aSelector | aMetaClass soleInstance]].

			selectors _ Set new.
			classes do:
				[:aClass |
					 (aClass additionsToViewerCategory: aCategorySymbol) do:
						[:anElement |
							anElement first == #command
								ifTrue:
									[selectors add: (aSelector _ anElement second).
									(methodInterfaces includesKey: aSelector) ifFalse:
										[methodInterfaces at: aSelector put: (MethodInterface new initializeFromEToyCommandSpec:  anElement category: aCategorySymbol)]]
								ifFalse:  "#slot format"
									[selectors add: (aSelector _ anElement seventh).  "the getter"
									selectors add: (anElement at: 9) "the setter".
									(methodInterfaces includesKey: aSelector) ifFalse:
										[self addGetterAndSetterInterfacesFromOldSlotSpec: anElement]]]].
			(selectors copyWithout: #unused) asSortedArray do:
				[:aSelector |
					aMethodCategory elementAt: aSelector put: (methodInterfaces at: aSelector)].
				 
			self addCategory: aMethodCategory].

	#(scripts 'instance variables') do: [:sym | self addCategoryNamed: sym].
	self setCategoryDocumentationStrings