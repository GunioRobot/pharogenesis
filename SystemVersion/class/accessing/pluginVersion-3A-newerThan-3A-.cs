pluginVersion: availableVersionString newerThan: currentVersionString
	| currentVersion availableVersion |
	(currentVersionString isEmptyOrNil
		or: [availableVersionString isEmptyOrNil])
		ifTrue: [^true].
	currentVersion _ self parseVersionString: currentVersionString.
	availableVersion _ self parseVersionString: availableVersionString.
	(currentVersion isNil
		or: [availableVersion isNil])
		ifTrue: [^false].
	^(currentVersion at: 2) < (availableVersion at: 2)