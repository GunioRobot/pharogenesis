remove: aClassNode
	(OBConfirmationRequest
		prompt: 'Are you certain that you 
want to REMOVE the class ', aClassNode theNonMetaClassName, ' from the system?'
		confirm: 'Remove')
			ifTrue: [aClassNode theNonMetaClass removeFromSystem.
					aClassNode signalDeletion]