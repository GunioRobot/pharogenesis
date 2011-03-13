handleNewStatusReplyFrom: dataStream sentBy: senderName ipAddress: ipAddressString

	(EToyGateKeeperMorph entryForIPAddress: ipAddressString) statusReplyReceived: (
		self newObjectFromStream: dataStream
	)
