removeDescriptionNamed: descriptionName

	| tt |
	Descriptions ifNil: [^ self].
	[(tt _  Descriptions detect: [:f | f name = descriptionName] ifNone: [nil]) notNil] whileTrue:[
		 Descriptions remove: tt
	].
