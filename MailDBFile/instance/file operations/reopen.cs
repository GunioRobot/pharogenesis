reopen
	"check the file size and mod time; if they match, then do a fast reopen.  Otherwise, read everything in the slow way"
	| entry |
	modTimeAtSave ifNil: [ ^self open ].
	sizeAtSave ifNil: [ ^self open ].

	entry := FileDirectory default entryAt: filename.
	entry ifNil: [ ^self open ].

	entry fileSize = sizeAtSave ifFalse: [ ^self open ].
	entry modificationTime = modTimeAtSave ifFalse: [ ^self open ].

