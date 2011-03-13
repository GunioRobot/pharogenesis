submorphNamed: aName ifNone: aBlock
	"Find the first submorph with this name, or a button with an action selector of that name"

	| sub args |
	self submorphs do: [:p | p knownName = aName ifTrue: [^ p]].
	self submorphs do: [:button |
		(button respondsTo: #actionSelector) ifTrue:
			[button actionSelector == aName ifTrue: [^ button]].
		((button respondsTo: #arguments) and: [(args _ button arguments) notNil])
			ifTrue: [(args at: 2 ifAbsent: [nil]) == aName ifTrue: [^ button]].
		(button isKindOf: AlignmentMorph) ifTrue:
			[(sub _ button submorphNamed: aName ifNone: [nil]) ifNotNil: [^ sub]]].
	^ aBlock value