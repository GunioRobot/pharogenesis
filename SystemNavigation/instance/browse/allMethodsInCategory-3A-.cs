allMethodsInCategory: category 
	| aCollection |
	aCollection := Set new.
	Cursor wait showWhile: [
			self allBehaviorsDo: [:x | ((category = ClassOrganizer allCategory
					ifTrue: [x organization allMethodSelectors]
					ifFalse: [x organization listAtCategoryNamed: category])) do:
				[:sel | aCollection add: (MethodReference new setStandardClass: x 
methodSymbol: sel)]]].
	^aCollection.
