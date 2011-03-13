addLine
	"Append a divider line to this menu. Suppress duplicate lines."
	self hasItems
		ifFalse: [^ self].
	(self lastSubmorph isKindOf: MenuLineMorph)
		ifFalse: [self addMorphBack: MenuLineMorph new] 