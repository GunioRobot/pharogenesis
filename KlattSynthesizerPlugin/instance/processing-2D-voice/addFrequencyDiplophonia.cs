addFrequencyDiplophonia
	"Add diplophonia (bicyclic voice). Change F0."
	self returnTypeC: 'void'.
	periodCount \\ 2 = 0
		ifTrue: [pitch _ pitch + ((frame at: Diplophonia) * (frame at: F0) * (1.0 - (frame at: Ro)))]
		ifFalse: [pitch _ pitch - ((frame at: Diplophonia) * (frame at: F0) * (1.0 - (frame at: Ro)))]