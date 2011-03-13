allImplementorsOf: aSelector localTo: aClass 
	"Answer a SortedCollection of all the methods that implement the message  
	aSelector in, above, or below the given class."
	| cls aCollection |
	aCollection := SortedCollection new.
	cls := aClass theNonMetaClass.
	Cursor wait
		showWhile: [cls
				withAllSuperAndSubclassesDoGently: [:class | (class includesSelector: aSelector)
						ifTrue: [aCollection
								add: (MethodReference new setStandardClass: class methodSymbol: aSelector)]].
			cls class
				withAllSuperAndSubclassesDoGently: [:class | (class includesSelector: aSelector)
						ifTrue: [aCollection
								add: (MethodReference new setStandardClass: class methodSymbol: aSelector)]]].
	^ aCollection