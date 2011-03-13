classFromPattern: pattern withCaption: aCaption
	"If there is a class whose name exactly given by pattern, return it.
	If there is only one class in the system whose name matches pattern, return it.
	Otherwise, put up a menu offering the names of all classes that match pattern, and return the class chosen, else nil if nothing chosen.
	This method ignores tab, space, & cr characters in the pattern"

	| toMatch potentialClassNames classNames exactMatch index |
	(toMatch _  pattern copyWithoutAll:
			{Character space.  Character cr.  Character tab})
		isEmpty ifTrue: [^ nil].
	Symbol hasInterned: toMatch ifTrue:
		[:patternSymbol | Smalltalk at: patternSymbol ifPresent:
			[:maybeClass | (maybeClass isKindOf: Class) ifTrue: [^ maybeClass]]].

	toMatch _ (toMatch copyWithout: $.) asLowercase.
	potentialClassNames _ (Smalltalk classNames , Smalltalk traitNames) asOrderedCollection.
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
			ifNil: [UIManager default chooseFrom: classNames lines: #() title: aCaption]
			ifNotNil: [classNames addFirst: exactMatch.
				UIManager default chooseFrom: classNames lines: #(1) title: aCaption]].
	index = 0 ifTrue: [^ nil].
	^ Smalltalk at: (classNames at: index) asSymbol

"
	self classFromPattern: 'CharRecog' withCaption: ''
	self classFromPattern: 'rRecog' withCaption: ''
	self classFromPattern: 'znak' withCaption: ''
	self classFromPattern: 'orph' withCaption: ''
	self classFromPattern: 'TCompil' withCaption: ''
"
