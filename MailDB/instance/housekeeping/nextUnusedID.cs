nextUnusedID
	"Answer the next unused message identifier. Message ID's are a monotonically increasing series roughly related to the time that they were requested. We use a block of message ID's based on the starting ID computed here. The last ID used is kept in LastID, to be sure that we don't reuse an already allocated ID."

	| id |
	"initialize LastID the first time it is used"
	(LastID isNil) ifTrue: [LastID _ 0].

 	"message ID's are roughly the number of seconds since the beginning of 1980"
	id _ Date today asSeconds + Time now asSeconds -
		(Date newDay: 1 year: 1980) asSeconds.
	id _ id max: (LastID + 1).  "never go backwards!"
	LastID _ id.
	^ id
