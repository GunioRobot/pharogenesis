writePrependingFile
	| result name prependedName |
	self canSaveArchive ifFalse: [ ^self ].
	result _ (StandardFileMenu newFileMenu: FileDirectory default)
		startUpWithCaption: 'Destination Zip File Name:'.
	result ifNil: [ ^self ].
	name _ result directory fullNameFor: result name.
	(archive canWriteToFileNamed: name)
		ifFalse: [ self inform: name, ' is used by one or more members
in your archive, and cannot be overwritten.
Try writing to another file name'.
			^self ].
	result _ (StandardFileMenu oldFileMenu: FileDirectory default)
		startUpWithCaption: 'Prepended File:'.
	result ifNil: [ ^self ].
	prependedName _ result directory fullNameFor: result name.
	[ archive writeToFileNamed: name prependingFileNamed: prependedName ]
		on: Error
		do: [ :ex | self inform: ex description. ].
	self changed: #memberList	"in case CRC's and compressed sizes got set"