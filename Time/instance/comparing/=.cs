= aTime 
	"Answer whether aTime represents the same second as the receiver."

	self species = aTime species
		ifTrue: [ ^seconds = aTime asSeconds ]
		ifFalse: [ ^false ].