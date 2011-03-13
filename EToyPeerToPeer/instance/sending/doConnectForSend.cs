doConnectForSend

	| addr |

	addr _ NetNameResolver addressForName: ipAddress.
	addr ifNil: [
		communicatorMorph commResult: {#message -> ('could not find ',ipAddress)}.
		^false
	].
	socket connectTo: addr port: self class eToyCommunicationsPort.
	(socket waitForConnectionUntil: (Socket deadlineSecs: 15)) ifFalse: [
		communicatorMorph commResult: {#message -> ('no connection to ',ipAddress,' (',
				(NetNameResolver stringFromAddress: addr),')')}.
		^false
	].
	^true

