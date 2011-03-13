step

	| needRebuild |
	super step.
	needRebuild _ false.
	(self valueOfProperty: #gateKeeperCounterValue) = 
			EToyGateKeeperMorph updateCounter ifFalse: [needRebuild _ true].
	updateCounter = UpdateCounter ifFalse: [
		needRebuild _ true.
	].
	needRebuild ifTrue: [self rebuild].
