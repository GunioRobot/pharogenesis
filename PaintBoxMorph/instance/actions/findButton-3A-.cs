findButton: aSelector
	"Find this button in me"

	submorphs do: [:button |
		(button respondsTo: #arguments) 
			ifTrue: [(button arguments at: 2) == aSelector ifTrue: [^ button]]
			ifFalse: [(button isKindOf: AlignmentMorph) ifTrue: [
				button submorphsDo: [:sub |
					(sub respondsTo: #arguments) 
						ifTrue: [(sub arguments at: 2) == aSelector ifTrue: [^ sub]]]]].
			].
	^ nil