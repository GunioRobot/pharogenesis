transmitEvent: aMorphicEvent
	"Transmit the given event to all remote connections."

	| sock status firstEvt |
	lastEventTransmitted = aMorphicEvent ifTrue: [^ self].
	transmitBuffer ifNil: [
		transmitBuffer _ WriteStream on: (String new: 10000)].
	transmitBuffer nextPutAll: aMorphicEvent storeString; cr.
	lastEventTransmitted _ aMorphicEvent.
	self readyToTransmit ifFalse: [^ self].

	self cleanupDeadConnections.
	remoteConnections do: [:triple |
		sock _ triple first.
		status _ triple at: 2.
		sock isConnected
			ifTrue: [
				status = #opening ifTrue: [
					"connection established; send worldExtent as first event"
					firstEvt _ MorphicEvent newWorldExtent: self worldBounds extent.
					sock sendData: firstEvt storeString, (String with: Character cr).
					Transcript
						show: 'Connection established with remote WorldMorph at ';
						show: (NetNameResolver stringFromAddress: sock remoteAddress); cr.
					triple at: 2 put: #connected].
				sock sendData: transmitBuffer contents]
			ifFalse: [
				status = #connected ifTrue: [
					"other end has closed; close our end"
					Transcript
						show: 'Closing connection with remote WorldMorph at ';
						show: (NetNameResolver stringFromAddress: sock remoteAddress); cr.
					sock close.
					triple at: 2 put: #closing]]].

	transmitBuffer reset.
