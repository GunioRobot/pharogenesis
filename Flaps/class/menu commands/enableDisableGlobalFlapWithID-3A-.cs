enableDisableGlobalFlapWithID: aFlapID
	"Toggle the enable/disable status of the given global flap"

	| disabledFlapIDs  aFlapTab currentProject |
	(currentProject _ Project current) assureFlapIntegrity.
	Smalltalk isMorphic ifFalse: [^ self].
	disabledFlapIDs _ currentProject parameterAt: #disabledGlobalFlapIDs.
	(aFlapTab _ self globalFlapTabWithID: aFlapID) ifNotNil:
		[aFlapTab hideFlap].
	(disabledFlapIDs includes: aFlapID)
		ifTrue:
			[disabledFlapIDs remove: aFlapID.
			self currentWorld addGlobalFlaps]
		ifFalse:
			[disabledFlapIDs add: aFlapID.
			aFlapTab ifNotNil: [aFlapTab delete]].
	self doAutomaticLayoutOfFlapsIfAppropriate