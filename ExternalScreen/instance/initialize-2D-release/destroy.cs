destroy
	"Destroy the receiver"
	allocatedForms ifNotNil:[
		allocatedForms lock. "Make sure we don't get interrupted"
		allocatedForms forceFinalization. "Clean up all lost references"
		allocatedForms keys do:[:stillValid| stillValid shutDown].
		"All remaining references are simply destroyed"
		allocatedForms associationsDo:[:assoc| assoc key: nil].
		allocatedForms forceFinalization. "destroy all others"
		allocatedForms _ nil.
	].
	bits ifNotNil:[self primDestroyDisplaySurface: bits].
	bits _ nil.