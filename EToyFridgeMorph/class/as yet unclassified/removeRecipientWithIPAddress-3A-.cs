removeRecipientWithIPAddress: ipString

	FridgeRecipients _ self fridgeRecipients reject: [ :each |
		ipString = each ipAddress
	].
	UpdateCounter _ self updateCounter + 1
