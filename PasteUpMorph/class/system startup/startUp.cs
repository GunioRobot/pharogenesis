startUp
	
	World ifNotNil:[
		World restoreMorphicDisplay.
		World triggerEvent: #aboutToEnterWorld.
	].