saveArchive
	| result name |
	self canSaveArchive ifFalse: [ ^self ].
	result := StandardFileMenu newFile.
	result ifNil: [ ^self ].
	name := result directory fullNameFor: result name.
	(archive canWriteToFileNamed: name)
		ifFalse: [ self inform: name, ' is used by one or more members
in your archive, and cannot be overwritten.
Try writing to another file name'.
			^self ].
	[ archive writeToFileNamed: name ] on: Error do: [ :ex | self inform: ex description. ].
	self setLabel: name asString.
	self changed: #memberList	"in case CRC's and compressed sizes got set"