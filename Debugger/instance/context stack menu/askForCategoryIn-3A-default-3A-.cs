askForCategoryIn: aClass default: aString
	| categories index category |
	categories := OrderedCollection with: 'new ...'. 
	categories addAll: (aClass allMethodCategoriesIntegratedThrough: Object).	
	index := PopUpMenu withCaption: 'Please provide a good category for the new method!' translated
						chooseFrom: categories.
	index = 0 ifTrue: [^ aString].
	category := index = 1 ifTrue: [FillInTheBlank request: 'Enter category name:']
						ifFalse: [categories at: index].
	^ category isEmpty ifTrue: [^ aString] ifFalse: [category]