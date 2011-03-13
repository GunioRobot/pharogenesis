updateIPAddressField: newAddresses
	
	targetIPAddresses _ (
		newAddresses copyWithout: NetNameResolver localAddressString
	) 
		asSet 
		asSortedCollection 
		asArray.

	(fields at: #ipAddress) contents: targetIPAddresses size printString,' people'.