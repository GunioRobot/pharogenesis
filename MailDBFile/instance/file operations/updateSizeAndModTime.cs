updateSizeAndModTime
	"update the cached size and modification time"
	| entry |
	entry := FileDirectory default entryAt: filename.
	entry ifNil: [
		"uh oh!"
		self reportInconsistency.
		sizeAtSave := nil.
		modTimeAtSave := nil.
		^self ].

	sizeAtSave := entry fileSize.
	modTimeAtSave := entry modificationTime.