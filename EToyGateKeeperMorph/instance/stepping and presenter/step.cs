step

	(self valueOfProperty: #gateKeeperCounterValue) = 
			EToyGateKeeperMorph updateCounter ifTrue: [^self].
	self rebuild.
