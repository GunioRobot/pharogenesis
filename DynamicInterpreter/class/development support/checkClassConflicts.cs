checkClassConflicts
	"DynamicInterpreter checkClassConflicts"
	"Browse source conflicts between DynamicInterpreter class and methods of the same name in Interpreter class"

	| coreSrc interpSrc coreSels interpSels conflicts selector |
	coreSels _ DynamicInterpreter class selectors asArray.
	interpSels _ Interpreter class selectors.
	conflicts _ IdentitySet new.

	('Comparing source...')
		displayProgressAt: Sensor cursorPoint
		from: 0 to: coreSels size
		during: [ :bar |
			1 to: coreSels size do: [:index |
				bar value: index.
				selector _ coreSels at: index.
				((interpSels includes: selector) and:
					[coreSrc _ (DynamicInterpreter class compiledMethodAt: selector) getSourceFromFile.
					interpSrc _ (Interpreter class compiledMethodAt: selector) getSourceFromFile.
					coreSrc ~= interpSrc])
						ifTrue: [conflicts add: 'DynamicInterpreter class ' , selector; add: 'Interpreter class ' , selector]]].
	Smalltalk
		browseMessageList: conflicts asSortedCollection
		name: 'DynamicInterpreter class conflicts'