accelerationSuspended: aBool
	"Temporarily suspend hardware acceleration"
	aBool
		ifTrue:[self setProperty: #accelerationSuspended toValue: aBool]
		ifFalse:[self removeProperty: #accelerationSuspended]