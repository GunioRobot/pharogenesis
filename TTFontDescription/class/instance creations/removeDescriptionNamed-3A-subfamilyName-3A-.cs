removeDescriptionNamed: descriptionName subfamilyName: subfamilyName

	| tts |
	Descriptions ifNil: [^ self].
	tts _ Descriptions select: [:f | f name = descriptionName and: [f subfamilyName = subfamilyName]].
	tts do: [:f | Descriptions remove: f].
