name
	| type nameField disposition |
	type _ self fields at: 'content-type' ifAbsent: [].
	(type notNil and: [(nameField _ type parameters at: 'name' ifAbsent: []) notNil])
		ifTrue: [^ nameField].
	disposition _ self fields at: 'content-disposition' ifAbsent: [].
	(disposition notNil and: [(nameField _ disposition parameters at: 'filename' ifAbsent: []) notNil])
		ifTrue: [^ nameField].
	^ nil