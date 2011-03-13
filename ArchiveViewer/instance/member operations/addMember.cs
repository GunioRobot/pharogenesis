addMember
	| result relative |
	self canAddMember ifFalse: [ ^self ].
	result := StandardFileMenu oldFile.
	result ifNil: [ ^self ].
	relative := result directory fullNameFor: result name.
	(relative beginsWith: FileDirectory default pathName)
		ifTrue: [ relative := relative copyFrom: FileDirectory default pathName size + 2 to: relative size ].
	(archive addFile: relative)
		desiredCompressionMethod: ZipArchive compressionDeflated.
	self memberIndex: self members size.
	self changed: #memberList.