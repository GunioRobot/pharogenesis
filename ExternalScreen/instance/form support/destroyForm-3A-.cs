destroyForm: anExternalForm
	"Destroy the given external form"
	self primDestroyForm: anExternalForm getExternalHandle.
	anExternalForm setExternalHandle: nil on: nil.
	allocatedForms removeKey: anExternalForm ifAbsent:[].