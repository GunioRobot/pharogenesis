transferServerDefinitionsToExternal
	"ServerDirectory transferServerDefinitionsToExternal"

	| serverDir |
	serverDir _ ExternalSettings preferenceDirectory directoryNamed: self serverConfDirectoryName.
	serverDir assureExistence.
	ServerDirectory storeCurrentServersIn: serverDir