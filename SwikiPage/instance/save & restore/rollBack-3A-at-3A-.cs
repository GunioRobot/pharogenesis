rollBack: aDate at: aTime
	"Roll back tthis page to a previous state.  This does not erase data, just moves an older version to the end."

	| theFile pp dd tt recentChunk page |
	theFile _ FileStream oldFileNamed: file.
	theFile setToEnd.
	[theFile position < 8 "beginning"] whileFalse: [
		self backupAChunk: theFile.
		pp _ theFile position.
		theFile upTo: $'; skip: -1.		"name"
		theFile nextDelimited: $'.
		theFile upTo: $'; skip: -1.		"date"
		dd _ (theFile nextDelimited: $') asDate.
		theFile upTo: $'; skip: -1.		"time"
		tt _ theFile nextDelimited: $'.
		theFile position: pp.
		(dd < aDate) | ((dd = aDate) & (tt asTime < aTime)) ifTrue: [
			recentChunk _ theFile nextChunk.
			theFile setToEnd.
			theFile nextChunkPut: recentChunk; cr; close.
			date _ dd.	"That's my date now"
			^ self]].
	"none that early, store out a blank page"
	theFile close.
	page _ map
		storeID: coreID
		text: 'blank text (but prevous versions do exist)'
		from: self peerName.
	page user: 'unknown user' "oldPage userID".
