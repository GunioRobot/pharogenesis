ircProtocolMessage: msg
	"a new message.  log it on the console, unless it's a channel listing"
	(msg command ~= IRCConnection RPLList printString
	and: [ msg command ~= IRCConnection RPLMotd ]) ifTrue: [
		self addToConsole: msg asString ].