readReference
	"PRIVATE -- Read the contents of an object reference. Cf. outputReference:.
	11/15/92 jhm: Support weak references.
	08:09 tk Data on file is relative to base position (where DataStream took over)."
	| referencePosition |

	^ (referencePosition _ (byteStream nextNumber: 4)) = self vacantRef	"relative"
		ifTrue:  [nil]
		ifFalse: [self objectAt: referencePosition]		"relative pos"