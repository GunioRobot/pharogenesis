text

	| theFile theText real bb gotTo |
	theFile _ FileStream oldFileNamed: file.
	theFile setToEnd.
	bb _ self backupAChunk: theFile.
	bb _ bb - 7.		"before the back:"
	"Be careful about occurances of 'text:' in the name or other field"
	[theFile match: 'text:'.
	gotTo _ theFile position.
	theFile upTo: $'; skip: -1.	
	theText _ theFile nextDelimited: $'.
	real _ (ReadStream on: theText) nextDelimited: $!.	"Remove double !"
	theFile skipSeparators.
	theFile position >= bb] whileFalse: [theFile position: gotTo].

	theFile close.
	^ real