readReference
	"PRIVATE -- Read the contents of an object reference. Cf. outputReference:.
	 11/15/92 jhm: Support weak references."
	| referencePosition |

	^ (referencePosition _ (byteStream nextNumber: 4)) = self vacantRef
		ifTrue:  [nil]
		ifFalse: [self objectAt: referencePosition]