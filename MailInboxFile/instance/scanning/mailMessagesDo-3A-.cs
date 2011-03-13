mailMessagesDo: aBlock
	"Invoke the given block for each message in the mail inbox. The block argument is the text of a new message."

	| fileStream stream msgStart msgSize msgText |
	fileStream _ CrLfFileStream readOnlyFileNamed: filename.
	Smalltalk garbageCollect.
	(fileStream size < (Smalltalk bytesLeft - 200000))
		ifTrue: [
			"if possible, buffer the entire file in memory for speed"
			stream _ ReadStream on: (fileStream contentsOfEntireFile).
			fileStream _ nil]
		ifFalse: [
			"otherwise, use the actual file stream, reading from disk"
			stream _ fileStream].

	self scanToNextMessageIn: stream.
	MailDB skipRestOfLine: stream.  "skip message delimiter"
	msgStart _ stream position.
	[self scanToNextMessageIn: stream] whileTrue: [
		msgSize _ stream position - msgStart.
		stream position: msgStart.
		msgText _ stream next: msgSize.
		MailDB skipRestOfLine: stream.  "skip message delimiter"
		msgStart _ stream position.
		aBlock value: msgText].

	"process final message"
	msgSize _ stream position - msgStart.
	msgSize > 0 ifTrue: [
		stream position: msgStart.
		msgText _ stream next: msgSize.
		aBlock value: msgText].

	fileStream = nil ifFalse: [fileStream close].