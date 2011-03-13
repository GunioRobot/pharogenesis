disableGlobalFlapWithID: aFlapID
	"Mark this project as having the given flapID disabled"

	| disabledFlapIDs  aFlapTab currentProject |
	(currentProject := Project current) assureFlapIntegrity.
	disabledFlapIDs := currentProject parameterAt: #disabledGlobalFlapIDs.
	(aFlapTab := self globalFlapTabWithID: aFlapID) ifNotNil:
		[aFlapTab hideFlap].
	(disabledFlapIDs includes: aFlapID)
		ifFalse:
			[disabledFlapIDs add: aFlapID].
	aFlapTab ifNotNil: [aFlapTab delete]

	