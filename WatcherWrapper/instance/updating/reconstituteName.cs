reconstituteName
	"Reconstitute the external name of the receiver"

	variableName ifNotNil:
		[self setNameTo: ('{1}''s {2}' translated format: {player externalName. variableName translated}).
		(self submorphWithProperty: #watcherLabel) ifNotNilDo:
			[:aLabel | aLabel contents: variableName asString, ' = ']]