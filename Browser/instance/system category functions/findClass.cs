findClass
	"Search for a class by name."
	| pattern foundClass classNames index toMatch exactMatch potentialClassNames |

	self okToChange ifFalse: [^ self classNotFound].
	pattern _ FillInTheBlank request: 'Class name or fragment?'.
	pattern isEmpty ifTrue: [^ self classNotFound].
	toMatch _ (pattern copyWithout: $.) asLowercase.
	potentialClassNames _ self potentialClassNames asOrderedCollection.
	classNames _ pattern last = $. 
		ifTrue: [potentialClassNames select:
					[:nm |  nm asLowercase = toMatch]]
		ifFalse: [potentialClassNames select: 
					[:n | n includesSubstring: toMatch caseSensitive: false]].
	classNames isEmpty ifTrue: [^ self classNotFound].
	exactMatch _ classNames detect: [:each | each asLowercase = toMatch] ifNone: [nil].

	index _ classNames size = 1
		ifTrue:	[1]
		ifFalse:	[exactMatch
			ifNil: [(PopUpMenu labelArray: classNames lines: #()) startUp]
			ifNotNil: [classNames addFirst: exactMatch.
				(PopUpMenu labelArray: classNames lines: #(1)) startUp]].
	index = 0 ifTrue: [^ self classNotFound].
	foundClass _ Smalltalk at: (classNames at: index) asSymbol.
 	self selectCategoryForClass: foundClass.
	self selectClass: foundClass
