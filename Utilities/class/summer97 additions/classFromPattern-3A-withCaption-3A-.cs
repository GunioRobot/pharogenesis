classFromPattern: pattern withCaption: aCaption
	"If there is a class whose name exactly given by pattern, return it.
	If there is only one class in the system whose name matches pattern, return it.
	Otherwise, put up a menu offering the names of all classes that match pattern, and return the class chosen, else nil if nothing chosen"

	| toMatch potentialClassNames classNames exactMatch index |
	pattern isEmpty ifTrue: [^ nil].
	Symbol hasInterned: pattern ifTrue:
		[:patternSymbol | Smalltalk at: patternSymbol ifPresent:
			[:maybeClass | (maybeClass isKindOf: Class) ifTrue: [^ maybeClass]]].

	toMatch _ (pattern copyWithout: $.) asLowercase.
	potentialClassNames _ Smalltalk classNames asOrderedCollection.
	classNames _ pattern last = $. 
		ifTrue: [potentialClassNames select:
					[:nm |  nm asLowercase = toMatch]]
		ifFalse: [potentialClassNames select: 
					[:n | n includesSubstring: toMatch caseSensitive: false]].
	classNames isEmpty ifTrue: [^ nil].
	exactMatch _ classNames detect: [:each | each asLowercase = toMatch] ifNone: [nil].

	index _ classNames size = 1
		ifTrue:	[1]
		ifFalse:	[exactMatch
			ifNil: [(PopUpMenu labelArray: classNames lines: #()) startUpWithCaption: aCaption]
			ifNotNil: [classNames addFirst: exactMatch.
				(PopUpMenu labelArray: classNames lines: #(1)) startUpWithCaption: aCaption]].
	index = 0 ifTrue: [^ nil].
	^ Smalltalk at: (classNames at: index) asSymbol

"
	Utilities classFromPattern: 'CharRecog'
	Utilities classFromPattern: 'rRecog'
	Utilities classFromPattern: 'znak'
	Utilities classFromPattern: 'orph'
"
