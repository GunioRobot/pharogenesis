accelerationEnabled: aBool
	"Enable or disable hardware acceleration"
	myRenderer ifNotNil:[
		myRenderer destroy.
		myRenderer _ nil].
	aBool
		ifTrue:[self setProperty: #accelerationEnabled toValue: aBool]
		ifFalse:[self removeProperty: #accelerationEnabled]