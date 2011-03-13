checkOnAFriend

	| gateKeeperEntry caption choices resp |

	gateKeeperEntry _ EToyGateKeeperMorph entryForIPAddress: self ipAddress.
	caption _ 
'Last name: ',gateKeeperEntry latestUserName,
'\Last message in: ',gateKeeperEntry lastIncomingMessageTimeString,
'\Last status check at: ',gateKeeperEntry lastTimeCheckedString,
'\Last status in: ',gateKeeperEntry statusReplyReceivedString.
	choices _ 'Get his status now\Send my status now' .
	resp _ (PopUpMenu labels: choices withCRs) startUpWithCaption: caption withCRs.
	resp = 1 ifTrue: [
		gateKeeperEntry lastTimeChecked: Time totalSeconds.
		self sendStatusCheck.
	].
	resp = 2 ifTrue: [
		self sendStatusReply.
	].
