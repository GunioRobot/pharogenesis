disableGlobalFlapWithID: aFlapID
	"Mark this project as having the given flapID disabled"

	| disabledFlapIDs  aFlapTab currentProject |
	(currentProject _ Project current) assureFlapIntegrity.
	Smalltalk isMorphic ifFalse: [^ self].
	disabledFlapIDs _ currentProject parameterAt: #disabledGlobalFlapIDs.
	(aFlapTab _ self globalFlapTabWithID: aFlapID) ifNotNil:
		[aFlapTab hideFlap].
	(disabledFlapIDs includes: aFlapID)
		ifFalse:
			[disabledFlapIDs add: aFlapID].
	aFlapTab ifNotNil: [aFlapTab delete]

	