fileStream
	"open the underlying file, and return a handle to it; the caller is responsible for closing the stream when finished"
	^FileStream fileNamed: filename