nextUnusedID
	"Answer the next unused message identifier number."

	"Each message needs to have a unique ID.  Message ID's are a monotonically increasing integers roughly related to the time that they were requested.  The last ID used is kept in lastIssuedMsgID, to guard against reuse (e.g. if the clock changes)."

	| id |
	(lastIssuedMsgID isNil) ifTrue: [ 		"find the largest msgID currently in this database"
		lastIssuedMsgID _ 0.
		indexFile keys do: [ :msgID | lastIssuedMsgID _ lastIssuedMsgID max: msgID].
		].

 	"message ID's are roughly the number of seconds since the beginning of 1980"
	id _ Date today asSeconds + Time now asSeconds -
		(Date newDay: 1 year: 1980) asSeconds.
	id _ id max: (lastIssuedMsgID + 1).  "never go backwards!"
	lastIssuedMsgID _ id.
	^ id

	"MailDB someInstance nextUnusedID"