delimitersDo: aBlock
	"Invoke the given block for each message in the mail inbox. The block argument is the text of a new message."

	| fileStream stream msgStart msgSize msgText delim |
	fileStream _ FileStream fileNamed: filename.
	Smalltalk garbageCollect.
	(fileStream size < (Smalltalk bytesLeft - 200000))
		ifTrue: [
			"if possible, buffer the entire file in memory for speed"
			stream _ ReadStream on: (fileStream contentsOfEntireFile).
			fileStream _ nil]
		ifFalse: [
			"otherwise, use the actual file stream, reading from disk"
			stream _ fileStream].

	[self scanToNextMessageIn: stream] whileTrue: [
		aBlock value: (MailDB readStringLineFrom: stream)].

	fileStream = nil ifFalse: [fileStream close].