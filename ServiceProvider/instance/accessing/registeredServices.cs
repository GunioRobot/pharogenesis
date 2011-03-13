registeredServices
	
	^ self services collect: [:each | self performAndSetId: each]