allMethodsSelect: aBlock 
	"Answer a SortedCollection of each method that, when used as the block  
	argument to aBlock, gives a true result."
	| aCollection |
	aCollection := SortedCollection new.
	Cursor execute
		showWhile: [self
				allBehaviorsDo: [:class | class
						selectorsDo: [:sel | (aBlock
									value: (class compiledMethodAt: sel))
								ifTrue: [aCollection
										add: (MethodReference new setStandardClass: class methodSymbol: sel)]]]].
	^ aCollection