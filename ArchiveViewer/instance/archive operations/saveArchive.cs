saveArchive
	| result name |
	
	name := FileDirectory  localNameFor: labelString .
	self canSaveArchive ifFalse: [ ^self ].
	result := FillInTheBlank
		request: 'Name this zip '
		initialAnswer:  name
		centerAt: Display center.
	result ifNil: [ ^self ].
	
	(archive canWriteToFileNamed: result)
		ifFalse: [ self inform: name, ' is used by one or more members
in your archive, and cannot be overwritten.
Try writing to another file name'.
			^self ].
	[ archive writeToFileNamed: result ] on: Error do: [ :ex | self inform: ex description. ].
	self setLabel: name asString.
	self changed: #memberList	"in case CRC's and compressed sizes got set"