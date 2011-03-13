saveCheckpoint: contentWithFilename
	"Save the map checkpoint to disk if it is not there already."

	| file directory sz fname content |
	directory := self directory.
	sz := contentWithFilename size.
	fname := contentWithFilename last: sz - (contentWithFilename lastIndexOf: $:).
	content := contentWithFilename first: sz - fname size - 1.
	(directory fileExists: fname) ifFalse: [
		[file := StandardFileStream newFileNamed: (directory fullNameFor: fname).
		file nextPutAll: content]
			ensure: [file close]]