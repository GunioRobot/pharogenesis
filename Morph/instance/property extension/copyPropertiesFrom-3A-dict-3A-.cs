copyPropertiesFrom: donorMorph dict: dict
	(extension _ donorMorph extension copy) == nil ifTrue: [^ self].
	extension copyPropertiesFrom: donorMorph dict: dict