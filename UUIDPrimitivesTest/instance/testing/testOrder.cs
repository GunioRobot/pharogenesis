testOrder
	| uuid1 uuid2 |
	100 timesRepeat:
		[uuid1 _ UUID new.
		uuid2 _ UUID new.
		(uuid1 asString last: 12) = (uuid2 asString last: 12) ifTrue:
			[self should: [uuid1 < uuid2].
			self should: [uuid2 > uuid1].
			self shouldnt: [uuid1 = uuid2]]]
