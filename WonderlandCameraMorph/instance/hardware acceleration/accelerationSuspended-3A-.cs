accelerationSuspended: aBool
	"Temporarily suspend hardware acceleration"
	myRenderer ifNotNil:[myRenderer destroy].
	myRenderer _ nil.
	aBool
		ifTrue:[self setProperty: #accelerationSuspended toValue: aBool]
		ifFalse:[self removeProperty: #accelerationSuspended]