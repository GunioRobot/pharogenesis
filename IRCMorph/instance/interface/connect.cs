connect
	connection ifNotNil: [ connection disconnect ].
	connection ifNil: [ connection _ IRCConnection new ].
	connection connectToServer: server  port: port nick: nick  user: userName  fullName: fullName.
	connection subscribeToDirectMessages: self.