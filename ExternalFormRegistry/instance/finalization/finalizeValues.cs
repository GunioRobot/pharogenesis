finalizeValues
	"This message is sent when an element has gone away."
	lockFlag == true ifTrue:[^self].
	self forceFinalization.