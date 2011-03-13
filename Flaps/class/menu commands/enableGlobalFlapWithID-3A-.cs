enableGlobalFlapWithID: aFlapID
	"Remove any memory of this flap being disabled in this project"

	| disabledFlapIDs  currentProject |
	(currentProject := Project current) assureFlapIntegrity.
	disabledFlapIDs := currentProject parameterAt: #disabledGlobalFlapIDs ifAbsent: [^ self].
	disabledFlapIDs remove: aFlapID ifAbsent: []
	