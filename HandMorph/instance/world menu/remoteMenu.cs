remoteMenu
	"Build the Telemorphic menu for the world."
	| menu |
	menu _ (MenuMorph entitled: 'Telemorphic') defaultTarget: self.
	menu addStayUpItem.
	menu add: 'local host address' action: #reportLocalAddress.
	menu add: 'connect remote user' action: #connectRemoteUser.
	menu add: 'disconnect remote user' action: #disconnectRemoteUser.
	menu add: 'disconnect all remote users' action: #disconnectAllRemoteUsers.
	^ menu