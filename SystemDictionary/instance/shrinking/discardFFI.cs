discardFFI
	"Discard the complete foreign function interface.
	NOTE: Recreates specialObjectsArray to prevent obsolete
	references. Has to specially remove external structure
	hierarchy before ExternalType"
	self
		at: #ExternalStructure
		ifPresent: [:cls | (ChangeSet superclassOrder: cls withAllSubclasses asArray)
				reverseDo: [:c | c removeFromSystem]].
	SystemOrganization removeCategoriesMatching: 'FFI-*'.
	self recreateSpecialObjectsArray.
	"Remove obsolete refs"
	ByteArray removeSelector: #asExternalPointer.
	ByteArray removeSelector: #pointerAt: