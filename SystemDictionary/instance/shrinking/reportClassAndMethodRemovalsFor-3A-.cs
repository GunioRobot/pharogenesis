reportClassAndMethodRemovalsFor: collectionOfClassNames
	| initialClassesAndMethods finalClassesAndMethods |
	"Smalltalk reportClassAndMethodRemovalsFor: #(Celeste Scamper MailMessage)"

	initialClassesAndMethods := self unusedClassesAndMethodsWithout: {{}. {}}.
	finalClassesAndMethods := self unusedClassesAndMethodsWithout: {collectionOfClassNames. {}}.
	^ {finalClassesAndMethods first copyWithoutAll: initialClassesAndMethods first.
		finalClassesAndMethods second copyWithoutAll: initialClassesAndMethods second}