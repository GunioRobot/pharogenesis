requestMotd
	self sendMessage: (IRCProtocolMessage command: 'motd')