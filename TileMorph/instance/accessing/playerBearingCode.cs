playerBearingCode
	"Answer the actual Player object who will be the 'self' when the receiver is being asked to generate code"

	self topEditor ifNotNilDo:
		[:anEditor | ^ anEditor playerScripted].
	(self nearestOwnerThat: [:m | m isAViewer]) 
		ifNotNilDo:
			[:aViewer | ^ aViewer scriptedPlayer].
	^ actualObject