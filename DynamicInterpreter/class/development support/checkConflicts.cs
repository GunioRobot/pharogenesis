checkConflicts
	"DynamicInterpreter checkConflicts"
	"Browse source conflicts between DynamicInterpreter and methods of the same name in Interpreter"

	| coreSrc interpSrc coreSels interpSels conflicts selector |
	coreSels _ DynamicInterpreter selectors asArray.
	interpSels _ Interpreter selectors.
	conflicts _ IdentitySet new.

	('Comparing source...')
		displayProgressAt: Sensor cursorPoint
		from: 0 to: coreSels size
		during: [ :bar |
			1 to: coreSels size do: [:index |
				bar value: index.
				selector _ coreSels at: index.
				((interpSels includes: selector) and:
					[coreSrc _ (DynamicInterpreter compiledMethodAt: selector) getSourceFromFile.
					interpSrc _ (Interpreter compiledMethodAt: selector) getSourceFromFile.
					coreSrc ~= interpSrc])
						ifTrue: [conflicts add: 'DynamicInterpreter ' , selector; add: 'Interpreter ' , selector]]].
	Smalltalk
		browseMessageList: conflicts asSortedCollection
		name: 'DynamicInterpreter conflicts'