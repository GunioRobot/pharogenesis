at: msgID put: anIndexFileEntry 
	"Associate the given IndexFileEntry with the given message ID."
	timeSortedEntries removeAllSuchThat: [:assoc | assoc key = msgID].
	"don't duplicate the entry!"
	self privateAt: msgID put: anIndexFileEntry.
	self logStream print: msgID;
	 cr.
	"message ID"
	anIndexFileEntry writeOn: self logStream.
	self logStream close