privateRemove: msgID 
	"Remove the entry with the given ID from my Dictionary."
	timeSortedEntries removeAllSuchThat: [:assoc | assoc key = msgID].
	msgDictionary removeKey: msgID ifAbsent: [].
	anyRemovalsSinceLastSave := true.