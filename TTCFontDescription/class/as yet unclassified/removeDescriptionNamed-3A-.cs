removeDescriptionNamed: descriptionName

	| tt |
	TTCDescriptions ifNil: [^ self].
	[(tt _ TTCDescriptions detect: [:f | ('Multi', f first name) = descriptionName] ifNone: [nil]) notNil] whileTrue:[
		 TTCDescriptions remove: tt
	].
