discardFFI
	"Discard the complete foreign function interface.
	NOTE: Recreates specialObjectsArray to prevent obsolete references. Has to specially remove external structure hierarchy before ExternalType"

	(ChangeSet superclassOrder: ExternalStructure withAllSubclasses asArray) reverseDo: 
		[:c | c removeFromSystem].
	Smalltalk removeKey: #FFIConstants ifAbsent: [].
	SystemOrganization removeCategoriesMatching: 'FFI-*'.
	Smalltalk recreateSpecialObjectsArray.