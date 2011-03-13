addMember
	| result local full |
	self canAddMember ifFalse: [ ^self ].
	result := FileList2 modalFileSelector .
	result ifNil: [ ^self ].
	
local := result directory localNameFor: result name.

	full := result directory fullNameFor: result name.
	
	(archive addFile: full as: local)
		desiredCompressionMethod: ZipArchive compressionDeflated.
	self memberIndex: self members size.
	self changed: #memberList.