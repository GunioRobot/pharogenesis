fetchExternalSettingsIn: aDirectory
	"Scan for server configuration files"
	"ServerDirectory fetchExternalSettingsIn: (FileDirectory default directoryNamed: 'prefs')"

	| serverConfDir stream |
	(aDirectory directoryExists: self serverConfDirectoryName)
		ifFalse: [^self].
	serverConfDir := aDirectory directoryNamed: self serverConfDirectoryName.
	serverConfDir fileNames do: [:fileName |
		stream := serverConfDir readOnlyFileNamed: fileName.
		stream
			ifNotNil: [
				[self parseServerEntryFrom: stream] ifError: [:err :rcvr | ].
				stream close]]