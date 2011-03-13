allAvailableDependenciesDo: aBlock
	| version |
	self dependencies do:
		[:ea |
		[version := ea resolve.
		version allAvailableDependenciesDo: aBlock.
		aBlock value: version]
			on: Error do: []]