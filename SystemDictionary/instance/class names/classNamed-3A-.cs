classNamed: className 
	"className is either a class name or a class name followed by ' class'.
	Answer the class or metaclass it names"

	| meta baseName baseClass |
	(className endsWith: ' class')
		ifTrue: [meta _ true.
				baseName _ className copyFrom: 1 to: className size - 6]
		ifFalse: [meta _ false.
				baseName _ className].
	baseClass _ Smalltalk at: baseName asSymbol ifAbsent: [^ nil].
	meta
		ifTrue: [^ baseClass class]
		ifFalse: [^ baseClass]