setStream: aStream
	"Feed it in from an existing source"
	stream _ JPEGReadStream on: aStream upToEnd.