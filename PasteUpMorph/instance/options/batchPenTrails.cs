batchPenTrails
	"Answer whether pen trails should be batched in the receiver"

	^ self valueOfProperty: #batchPenTrails ifAbsent: [Preferences batchPenTrails]