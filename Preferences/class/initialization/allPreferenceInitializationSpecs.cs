allPreferenceInitializationSpecs
	"Preferences allPreferenceInitializationSpecs"
	| aList additions |
	aList _ OrderedCollection new.
	(self class organization listAtCategoryNamed: 'initial values' asSymbol) do:
		[:aSelector | aSelector numArgs = 0 ifTrue:
			[additions _ self perform: aSelector.
			(additions isKindOf: Collection) ifFalse: [self error: 'method in "initial values" categories must return collections'].
			aList addAll: additions]].
	^ aList
			