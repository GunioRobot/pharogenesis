addLine
	"Append a divider line to this menu. Suppress duplicate lines."

	submorphs isEmpty ifTrue: [^ self].
	(self lastSubmorph isKindOf: MenuLineMorph)
		ifFalse: [self addMorphBack: MenuLineMorph new].
