newsMessagesDo: aBlock
	"Invoke the given block for each message in the news inbox file. The block arguments are the newsgroup name and the text of a new message."

	| fileStream stream |
	fileStream _ FileStream fileNamed: filename.
	(fileStream size < 50000)
		ifTrue:
			["for small inboxes, buffer the entire file in memory for speed"
			 stream _ ReadStream on: (fileStream contentsOfEntireFile)]
		ifFalse:
			["otherwise, use the actual file stream, reading from disk"
			 stream _ fileStream].
	self parse: stream do: aBlock.
	fileStream close.