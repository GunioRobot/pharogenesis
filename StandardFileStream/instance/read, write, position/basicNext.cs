basicNext
	"Answer the next byte from this file, or nil if at the end of the file."

	| count |
	count _ self primRead: fileID into: buffer1 startingAt: 1 count: 1.
	count = 1
		ifTrue: [^ buffer1 at: 1]
		ifFalse: [^ nil].
