needsUpload
	"Return true if the receiver needs to be uploaded"
	bits isInteger ifTrue:[^false]. "handled transparently"
	^bits size = self bitsSize