at: msgID put: anIndexFileEntry 
	"Associate the given IndexFileEntry with the given message ID."
	| fileStream |
	self privateAt: msgID put: anIndexFileEntry.
	
	"save the entry immediately to disk"
	fileStream := self fileStream .
	fileStream setToEnd.
	fileStream
		print: msgID;
	 	cr.
	anIndexFileEntry writeOn: fileStream.
	fileStream close.
	self updateSizeAndModTime.