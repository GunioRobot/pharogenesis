saveCheckpoint: contentWithFilename
	"Save the map checkpoint to disk if it is not there already."

	| file directory sz fname content |
	directory _ self directory.
	sz _ contentWithFilename size.
	fname _ contentWithFilename last: sz - (contentWithFilename lastIndexOf: $:).
	content _ contentWithFilename first: sz - fname size - 1.
	(directory fileExists: fname) ifFalse: [
		["file _ directory newFileNamed: (directory nextNameFor: 'map' extension: 'sgz')."
		file _ directory newFileNamed: fname.
		file converter: Latin1TextConverter new.
		file nextPutAll: content]
			ensure: [file close]]