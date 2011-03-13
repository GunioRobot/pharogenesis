acceptRequest: requestType from: senderName at: ipAddressString

	| entry |

	UpdateCounter _ self updateCounter + 1.
	entry _ self entryForIPAddress: ipAddressString.
	senderName isEmpty ifFalse: [entry latestUserName: senderName].
	^entry requestAccessOfType: requestType