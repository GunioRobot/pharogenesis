textVersion: steps
	"One step back gets the original"
	| theFile theText real bb gotTo count |
	theFile _ FileStream oldFileNamed: file.
	theFile setToEnd.
	bb _ 1. count _ steps.
	[count > 0 and: [bb > 0]] whileTrue: [
		bb _ self backupAChunk: theFile. count := count - 1.].
	bb = 0 ifTrue: ["Went back beyond beginning"
		theFile close.
		^'<Too Far Back>'.].
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