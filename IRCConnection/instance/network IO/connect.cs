connect
	"connect to a server"
	| addr |

	Socket initializeNetwork.
	socket ifNotNil: [ socket destroy ].
	self reset.

	Utilities informUser: 'looking up server address...' during: [
		addr _ NetNameResolver addressForName: server ].
	addr ifNil: [ ^PopUpMenu notify: 'could not find address for ', server ].

	socket _ Socket new.
	socket connectTo: addr  port: port.

	self sendMessage: (IRCProtocolMessage fromString: 'NICK ', nick).
	self sendMessage: (IRCProtocolMessage fromString: 'USER ', userName, ' * * :', fullName).