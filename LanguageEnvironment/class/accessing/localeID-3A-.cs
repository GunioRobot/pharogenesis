localeID: localeID
	^self knownEnvironments at: localeID ifAbsentPut: [self new localeID]