elementsExchangeIdentityWith: otherArray
	"This primitive performs a bulk mutation, causing all pointers to the elements of this array to be replaced by pointers to the corresponding elements of otherArray.  At the same time, all pointers to the elements of otherArray are replaced by pointers to the corresponding elements of this array.  The identityHashes remain with the pointers rather than with the objects so that objects in hashed structures should still be properly indexed after the mutation."
	<primitive: 128>
	self primitiveFailed