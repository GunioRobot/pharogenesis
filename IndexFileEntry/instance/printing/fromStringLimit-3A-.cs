fromStringLimit: limit
	"Answer a cleaned up 'from' field for the table of contents."

	| editedFrom s ch i |
	editedFrom _ WriteStream on: (String new: limit + 1).
	s _ ReadStream on: from.
	s skipSeparators.
	('"<' includes: s peek) ifTrue: [s next].
	((i _ from indexOf: $() > 0) ifTrue: [s position: i].
	[s atEnd] whileFalse: [
		ch _ s next.
		(('@<>)$"' includes: ch) or: [editedFrom position >= limit])
			ifTrue: [^editedFrom contents]
			ifFalse: [editedFrom nextPut: ch]].
	^editedFrom contents
