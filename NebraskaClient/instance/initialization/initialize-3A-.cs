initialize: aConnection

	| remoteAddress userPicture |

	connection := aConnection.
	hand := RemoteControlledHandMorph on: (MorphicEventDecoder on: aConnection).
	hand nebraskaClient: self.
	remoteAddress _ connection remoteAddress.
	remoteAddress ifNotNil: [remoteAddress _ NetNameResolver stringFromAddress: remoteAddress].
	userPicture _ EToySenderMorph pictureForIPAddress: remoteAddress.
	hand
		userInitials: ((EToySenderMorph nameForIPAddress: remoteAddress) ifNil: ['???'])
		andPicture: (userPicture ifNotNil: [userPicture scaledToSize: 16@20]).
	encoder := CanvasEncoder on: aConnection.
	canvas := RemoteCanvas
		connection: encoder
		clipRect: NebraskaServer extremelyBigRectangle
		transform: MorphicTransform identity