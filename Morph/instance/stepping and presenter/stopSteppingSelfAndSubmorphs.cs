stopSteppingSelfAndSubmorphs
	self allMorphsDo: [:m | m stopStepping]
