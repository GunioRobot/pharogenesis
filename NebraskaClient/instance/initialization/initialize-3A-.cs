initialize: aConnection

	| remoteAddress userPicture |

	connection := aConnection.
	hand := RemoteControlledHandMorph on: (MorphicEventDecoder on: aConnection).
	hand nebraskaClient: self.
	remoteAddress := connection remoteAddress.
	remoteAddress ifNotNil: [remoteAddress := NetNameResolver stringFromAddress: remoteAddress].
	userPicture := EToySenderMorph pictureForIPAddress: remoteAddress.
	hand
		userInitials: ((EToySenderMorph nameForIPAddress: remoteAddress) ifNil: ['???'])
		andPicture: (userPicture ifNotNil: [userPicture scaledToSize: 16@20]).
	encoder := CanvasEncoder on: aConnection.
	canvas := RemoteCanvas
		connection: encoder
		clipRect: NebraskaServer extremelyBigRectangle
		transform: MorphicTransform identity