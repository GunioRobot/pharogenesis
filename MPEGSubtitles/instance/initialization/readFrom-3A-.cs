readFrom: aStream 
	"private - Read the next definitions found in aStream onto the  
	receiver"
	[aStream atEnd]
		whileFalse: [| element | 
			element := MPEGSubtitleElement fromStream: aStream.
			elements add: element]