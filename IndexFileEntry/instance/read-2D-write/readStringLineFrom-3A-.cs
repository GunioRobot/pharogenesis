readStringLineFrom: aStream

	| line |
	line _ MailDB readStringLineFrom: aStream.
	[line _ line decodeMimeHeader]
		on: Error
		do: [:ex |
			Transcript
				cr; show: ex messageText;
				space; nextPutAll: 'during: ';
				space; nextPutAll: line printString;
				space; nextPutAll: 'decodeMimeHeader'].
	^line isoToSqueak