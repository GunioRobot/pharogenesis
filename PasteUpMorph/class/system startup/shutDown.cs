shutDown
	
	World ifNotNil:[
		World triggerEvent: #aboutToLeaveWorld.
	].