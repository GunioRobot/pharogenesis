nextMolecule
	| current morph |
	selected
		ifNil: [current _ 0]
		ifNotNil: [current _ submorphs indexOf: selected].
	"get the next molecule since the current"
	current + 1
		to: submorphs size
		do: [:index | 
			morph _ submorphs at: index.
(			(morph isKindOf: AtomicAtom) and: [morph isMovable])
						ifTrue: [^ morph]].
	"nothing"
	^ nil