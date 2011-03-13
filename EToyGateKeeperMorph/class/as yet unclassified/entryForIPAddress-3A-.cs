entryForIPAddress: ipAddressString

	| known entry |

	UpdateCounter _ self updateCounter + 1.
	known _ self knownIPAddresses.
	entry _ known at: ipAddressString ifAbsentPut: [
		entry _ EToyGateKeeperEntry new.
		entry ipAddress: ipAddressString.
		entry
	].
	^entry