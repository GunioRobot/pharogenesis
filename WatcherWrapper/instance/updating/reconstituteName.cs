reconstituteName
	"Reconstitute the external name of the receiver"

	variableName ifNotNil:
		[self setNameTo: player externalName, '''s ', variableName.
		(self submorphWithProperty: #watcherLabel) ifNotNilDo:
			[:aLabel | aLabel contents: variableName asString, ' = ']]