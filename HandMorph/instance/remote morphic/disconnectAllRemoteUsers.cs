disconnectAllRemoteUsers
	"Disconnect all remote hands and stop transmitting events."

	| addr |
	self world hands do: [:h |
		(h isKindOf: RemoteHandMorph) ifTrue: [
			addr _ h remoteHostAddress.
			addr = 0 ifFalse: [self stopTransmittingEventsTo: addr].
			h withdrawFromWorld]].

	remoteConnections do: [:triple | triple first closeAndDestroy: 5].
	remoteConnections _ OrderedCollection new.
