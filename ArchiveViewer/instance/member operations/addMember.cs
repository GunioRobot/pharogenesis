addMember
	| result relative |
	self canAddMember ifFalse: [ ^self ].
	result _ StandardFileMenu oldFile.
	result ifNil: [ ^self ].
	relative _ result directory fullNameFor: result name.
	(relative beginsWith: FileDirectory default pathName)
		ifTrue: [ relative _ relative copyFrom: FileDirectory default pathName size + 2 to: relative size ].
	(archive addFile: relative)
		desiredCompressionMethod: ZipArchive compressionDeflated.
	self memberIndex: self members size.
	self changed: #memberList.