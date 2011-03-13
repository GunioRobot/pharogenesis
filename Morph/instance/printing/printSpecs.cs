printSpecs

	| printSpecs |

	printSpecs _ self valueOfProperty: #PrintSpecifications.
	printSpecs ifNil: [
		printSpecs _ PrintSpecifications defaultSpecs.
		self printSpecs: printSpecs.
	].
	^printSpecs