accelerationEnabled: aBool
	"Enable or disable hardware acceleration"
	| aWorld |
	"no dangling renderers please"
	myRenderer ifNotNil:[myRenderer destroy].
	myRenderer _ nil.
	aBool
		ifTrue:[self setProperty: #accelerationEnabled toValue: aBool]
		ifFalse:[self removeProperty: #accelerationEnabled].
	"For now make sure we're registered with the world in case this guy came from the disk"
	(aWorld _ self world) ifNotNil:[
		aWorld removeActionsWithReceiver: self.
		aWorld when: #aboutToLeaveWorld send: #suspendAcceleration to: self.
		aWorld when: #aboutToEnterWorld send: #restoreAcceleration to: self.
	].