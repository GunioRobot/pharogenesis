intoWorld: aWorld
	"The receiver is showing in the given world"
	aWorld ifNil:[^self].
	super intoWorld: aWorld.
	aWorld when: #aboutToLeaveWorld send: #suspendAcceleration to: self.
	aWorld when: #aboutToEnterWorld send: #restoreAcceleration to: self.
	self restoreAcceleration.