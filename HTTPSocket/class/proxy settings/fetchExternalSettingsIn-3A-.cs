fetchExternalSettingsIn: aDirectory
	"Scan for server configuration files"
	"HTTPSocket fetchExternalSettingsIn: (FileDirectory default directoryNamed: 'prefs')"

	| stream entries |
	(aDirectory fileExists: self proxySettingsFileName)
		ifFalse: [^self].
	stream _ aDirectory readOnlyFileNamed: self proxySettingsFileName.
	stream
		ifNotNil: [
			[entries _ ExternalSettings parseServerEntryArgsFrom: stream]
				ensure: [stream close]].

	entries ifNil: [^self].

	HTTPProxyServer _ entries at: 'host' ifAbsent: [nil].
	HTTPProxyPort _ (entries at: 'port' ifAbsent: ['80']) asInteger ifNil: [self defaultPort].
	HTTPSocket addProxyException: (entries at: 'exception' ifAbsent: [nil])