fullName
	"For compatibility with FileList services.
	If this is called, it means that a service that requires a real filename has been requested.
	So extract the selected member to a temporary file and return that name."

	| fullName dir |
	self canExtractMember ifFalse: [ ^nil ].
	dir _ FileDirectory default directoryNamed: '.archiveViewerTemp'.
	fullName _ dir fullNameFor: self selectedMember localFileName.
	self selectedMember extractInDirectory: dir.
	^fullName