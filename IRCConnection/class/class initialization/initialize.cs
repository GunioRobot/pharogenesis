initialize
	"IRCConnection initialize"


	self initializeMessageHandlers.

	DefaultServer _ 'us.chatnet.org'.
	DefaultPort _ 6667.
	DefaultNick _ 'nick'.
	DefaultUserName _ 'username'.
	DefaultFullName _ 'J. Doe <jdoe@somewhere>'.