fetchExternalSettingsIn: aDirectory
	"Scan for server configuration files"
	"ServerDirectory fetchExternalSettingsIn: (FileDirectory default directoryNamed: 'prefs')"

	| serverConfDir stream |
	(aDirectory directoryExists: self serverConfDirectoryName)
		ifFalse: [^self].
	self resetLocalProjectDirectories.
	serverConfDir _ aDirectory directoryNamed: self serverConfDirectoryName.
	serverConfDir fileNames do: [:fileName |
		stream _ serverConfDir readOnlyFileNamed: fileName.
		stream
			ifNotNil: [
				[self parseServerEntryFrom: stream] ifError: [:err :rcvr | ].
				stream close]]