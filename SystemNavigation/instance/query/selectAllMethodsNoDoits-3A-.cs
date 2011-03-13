selectAllMethodsNoDoits: aBlock 
	"Like allSelect:, but strip out Doits"
	| aCollection |
	aCollection := SortedCollection new.
	Cursor execute
		showWhile: [self
				allBehaviorsDo: [:class | class
						selectorsDo: [:sel | (sel isDoIt not
									and: [aBlock
											value: (class compiledMethodAt: sel)])
								ifTrue: [aCollection
										add: (MethodReference new setStandardClass: class methodSymbol: sel)]]]].
	^ aCollection