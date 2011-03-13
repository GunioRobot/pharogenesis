incomingMessgage: dataStream fromIPAddress: ipAddress

	| nullChar messageType senderName  selectorAndReceiver |

	nullChar _ 0 asCharacter.
	messageType _ dataStream upTo: nullChar.
	senderName _ dataStream upTo: nullChar.
	(EToyGateKeeperMorph acceptRequest: messageType from: senderName at: ipAddress) ifFalse: [
		^self
	].
	selectorAndReceiver _ self class messageHandlers at: messageType ifAbsent: [^self].
	^selectorAndReceiver second 
		perform: selectorAndReceiver first 
		withArguments: {dataStream. senderName. ipAddress}

