assuredPreferenceDirectory
	"Answer the preference directory, creating it if necessary"

	|  prefDir |
	prefDir _ self preferenceDirectory.
	prefDir
		ifNil:
			[prefDir _ FileDirectory default directoryNamed: self preferenceDirectoryName.
			prefDir assureExistence].
	^ prefDir