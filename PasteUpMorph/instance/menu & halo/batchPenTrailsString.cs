batchPenTrailsString
	"Answer the string to be shown in a menu to represent the batch-pen-trails enabled status"

	^ self batchPenTrails
		ifTrue:
			['<on>batch pen trails']
		ifFalse:
			['<off>batch pen trails']
