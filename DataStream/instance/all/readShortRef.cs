readShortRef
	"Read an object reference from two bytes only.  Original object must be in first 65536 bytes of the file."
	| referencePosition |

	^ (referencePosition _ (byteStream nextNumber: 2)) = self vacantRef	"relative"
		ifTrue:  [nil]
		ifFalse: [self objectAt: referencePosition]		"relative pos"