reportClassAndMethodRemovalsFor: collectionOfClassNames
	| initialClassesAndMethods finalClassesAndMethods |
	"Smalltalk reportClassAndMethodRemovalsFor: #(Celeste Scamper MailMessage)"

	initialClassesAndMethods _ self unusedClassesAndMethodsWithout: {{}. {}}.
	finalClassesAndMethods _ self unusedClassesAndMethodsWithout: {collectionOfClassNames. {}}.
	^ {finalClassesAndMethods first copyWithoutAll: initialClassesAndMethods first.
		finalClassesAndMethods second copyWithoutAll: initialClassesAndMethods second}