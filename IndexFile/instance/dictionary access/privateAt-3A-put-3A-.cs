privateAt: msgID put: anIndexFileEntry 
	"Associate the given IndexFileEntry with the given message ID."
	timeSortedEntries removeAllSuchThat: [:assoc | assoc key = msgID].
	"don't duplicate the entry!"
	msgDictionary at: msgID put: anIndexFileEntry.
	timeSortedEntries add: (Association key: msgID value: anIndexFileEntry).
	