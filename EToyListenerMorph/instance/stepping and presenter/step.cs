step

	| needRebuild |
	super step.
	needRebuild := false.
	(self valueOfProperty: #gateKeeperCounterValue) = 
			EToyGateKeeperMorph updateCounter ifFalse: [needRebuild := true].
	updateCounter = UpdateCounter ifFalse: [
		needRebuild := true.
	].
	needRebuild ifTrue: [self rebuild].
