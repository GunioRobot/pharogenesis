getCharacters
	"obtain a string value from the receiver"

	^ String streamContents:
		[:aStream |
			submorphs do:
				[:m | aStream nextPutAll: m getCharacters]]