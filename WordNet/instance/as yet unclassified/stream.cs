stream

	rwStream _  RWBinaryOrTextStream on: (String new: 1000).
	rwStream nextPutAll: replyHTML; reset.
	^ rwStream