insertionIndexFor: aMorph
	"Return the index at which the given morph should be inserted into the submorphs of the receiver."

	| newCenter |
	newCenter _ aMorph fullBounds center.
	orientation == #horizontal ifTrue:
		[submorphs doWithIndex: [:m :i |
			newCenter x < m fullBounds center x ifTrue: [^ i]]].
	orientation == #vertical ifTrue:
		[submorphs doWithIndex: [:m :i |
			newCenter y < m fullBounds center y ifTrue: [^ i]]].

	^ submorphs size + 1  "insert after the last submorph"
