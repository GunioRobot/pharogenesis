initialize
	self reset.

	server _ DefaultServer.
	port _ DefaultPort.
	nick _ DefaultNick.
	userName _ DefaultUserName.
	fullName _ DefaultFullName.

	directMessageSubscribers _ IdentitySet new.
	protocolMessageSubscribers _ IdentitySet new.

	consoleText _ Text new.