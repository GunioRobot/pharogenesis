processShutDownList: quitting
	"Send #shutDown to each class that needs to wrap up before a snapshot."

	self send: #shutDown: toClassesNamedIn: ShutDownList with: quitting.
