initializeAllInstances
	self allSubInstancesDo: [ :each | each properlyInitialize ]