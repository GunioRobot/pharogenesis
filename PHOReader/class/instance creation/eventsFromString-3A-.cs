eventsFromString: aString
	^ self eventsFromStream: (ReadStream on: aString)