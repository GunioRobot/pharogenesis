outOfWorld: aWorld
	"The receiver is leaving the given world"
	aWorld ifNil:[^self].
	self suspendAcceleration.
	aWorld removeActionsWithReceiver: self.
	super outOfWorld: aWorld.