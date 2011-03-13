checkOnAFriend

	| gateKeeperEntry caption choices resp |

	gateKeeperEntry := EToyGateKeeperMorph entryForIPAddress: self ipAddress.
	caption := 
'Last name: ',gateKeeperEntry latestUserName,
'\Last message in: ',gateKeeperEntry lastIncomingMessageTimeString,
'\Last status check at: ',gateKeeperEntry lastTimeCheckedString,
'\Last status in: ',gateKeeperEntry statusReplyReceivedString.
	choices := 'Get his status now\Send my status now' .
	resp := (PopUpMenu labels: choices withCRs) startUpWithCaption: caption withCRs.
	resp = 1 ifTrue: [
		gateKeeperEntry lastTimeChecked: Time totalSeconds.
		self sendStatusCheck.
	].
	resp = 2 ifTrue: [
		self sendStatusReply.
	].
