startUp
	"Look for external defs and load them."
	"ExternalSettings startUp"

	| prefDir |
	prefDir _ self preferenceDirectory.
	prefDir
		ifNil: [^self].
	self registeredClients do: [:client | 
		client fetchExternalSettingsIn: prefDir]