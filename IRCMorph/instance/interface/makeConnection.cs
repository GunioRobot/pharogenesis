makeConnection
	connection ifNotNil: [ connection disconnect ].
	connection ifNil: [ connection _ IRCConnection new ].
	connection connectToServer: server  port: port nick: nick  user: userName  fullName: fullName.
	connection requestChannelList.    "this is usually necessary, so go ahead and ask for it"