quit
	"tell the server we are leaving"
	self sendMessage: (IRCProtocolMessage command: 'quit')