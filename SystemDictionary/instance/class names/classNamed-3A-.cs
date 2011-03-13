classNamed: className 
	"className is either a class name or a class name followed by ' class'.
	Answer the class or metaclass it names.
	8/91 sw chgd so returns nil if class not found, to correct failures in Change Sorter across class renames"
	| meta baseName baseClass length |
	length _ className size.
	(length > 6 and: 
			[(className copyFrom: length - 5 to: length) = ' class'])
		ifTrue: 
			[meta _ true.
			baseName _ className copyFrom: 1 to: length - 6]
		ifFalse: 
			[meta _ false.
			baseName _ className].
	baseClass _ Smalltalk at: baseName asSymbol ifAbsent: [nil].
	baseClass isNil ifTrue: [^ nil].
	meta
		ifTrue: [^baseClass class]
		ifFalse: [^baseClass]