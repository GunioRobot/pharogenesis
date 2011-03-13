addressesForName: hostName
	"NetNameResolver addressesForName: 'impara.de' "
	| adresses |
	adresses := SocketAddressInformation
		forHost: hostName
		service: ''
		flags: 0
		addressFamily: 0
		socketType: SocketAddressInformation socketTypeStream
		protocol: SocketAddressInformation protocolTCP.
	^adresses