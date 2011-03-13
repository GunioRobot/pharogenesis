entryForIPAddress: ipAddressString

	| known entry |

	UpdateCounter := self updateCounter + 1.
	known := self knownIPAddresses.
	entry := known at: ipAddressString ifAbsentPut: [
		entry := EToyGateKeeperEntry new.
		entry ipAddress: ipAddressString.
		entry
	].
	^entry