doConnectForSend

	| addr |

	addr _ NetNameResolver addressForName: ipAddress.
	addr ifNil: [
		communicatorMorph commResult: {#message -> ('could not find ',ipAddress)}.
		^false
	].
	socket connectNonBlockingTo: addr port: self class eToyCommunicationsPort.
	[socket waitForConnectionFor: 15]
		on: ConnectionTimedOut
		do: [:ex |
			communicatorMorph commResult: {#message -> ('no connection to ',ipAddress,' (',
				(NetNameResolver stringFromAddress: addr),')')}.
			^false].
	^true

