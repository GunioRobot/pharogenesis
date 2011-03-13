stopServer
	"Shut down the server."

	ServerProcess	ifNotNil: [ServerProcess terminate].
	ServerPort		ifNotNil: [ServerPort destroy].
	ServerLog		ifNotNil: [ServerLog close].
	ServerProcess _ ServerPort _ ServerLog _ ClientNameCache _ nil.
