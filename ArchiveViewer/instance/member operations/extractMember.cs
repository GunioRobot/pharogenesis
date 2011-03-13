extractMember
	"Extract the member after prompting for a filename.
	Answer the filename, or nil if error."

	| result name |
	self canExtractMember ifFalse: [ ^nil ].
	result := StandardFileMenu newFile.
	result ifNil: [ ^nil ].
	name := (result directory fullNameFor: result name).
	(archive canWriteToFileNamed: name)
		ifFalse: [ self inform: name, ' is used by one or more members
in your archive, and cannot be overwritten.
Try extracting to another file name'.
			^nil ].
	self selectedMember extractToFileNamed: name.
	^name