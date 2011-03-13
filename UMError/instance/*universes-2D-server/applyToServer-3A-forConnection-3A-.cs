applyToServer: server forConnection: connection
	"if the client sends an error back, then the connection is really messed up"
	server destroyConnection: connection
	