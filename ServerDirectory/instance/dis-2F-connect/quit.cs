quit
	"break the connection"

	self keepAlive
		ifFalse: [self quitClient]