readFrom: aStream
	"Initialize myself from the given text stream. It is assumed that the 
	.index file was written in order of ascending message timestamps, 
	although this method is only less efficient, not incorrect, if this is not 
	the case."
	| sorted lastTime msgID entry |
	msgDictionary _ PluggableDictionary integerDictionary.
	timeSortedEntries _ (SortedCollection new: 1000)
				sortBlock: [:m1 :m2 | m1 value time <= m2 value time].
	sorted _ true.
	lastTime _ nil.
	[aStream atEnd]
		whileFalse: 
			[msgID _ MailDB readIntegerLineFrom: aStream.
			entry _ IndexFileEntry
						readFrom: aStream
						messageFile: messageFile
						msgID: msgID.
			msgDictionary at: msgID put: entry.
			timeSortedEntries addLast: (Association key: msgID value: entry).
			(sorted & lastTime notNil and: [lastTime > entry time])
				ifTrue: [sorted _ false].
			lastTime _ entry time].
	sorted ifFalse: [timeSortedEntries reSort].

	anyRemovalsSinceLastSave := false.