writeOn: aStream
	"Write my index entries to the given text stream in human-readable form."
	"Note: For efficiency, this is done in order of increasing message timestamps, to save the cost of sorting when we read it back in. It is assumed that timeSortedEntries should contains exactly the same message ID's as msgDictionary."

	timeSortedEntries do:
		[: assoc |
		 (assoc key) printOn: aStream.		"message ID"
		 aStream cr.
		 (assoc value) writeOn: aStream].	"index entry"

	anyRemovalsSinceLastSave := false.