enableGlobalFlapWithID: aFlapID
	"Remove any memory of this flap being disabled in this project"

	| disabledFlapIDs  currentProject |
	(currentProject _ Project current) assureFlapIntegrity.
	Smalltalk isMorphic ifFalse: [^ self].
	disabledFlapIDs _ currentProject parameterAt: #disabledGlobalFlapIDs ifAbsent: [^ self].
	disabledFlapIDs remove: aFlapID ifAbsent: []
	