testCreationEquality
	| uuid1 uuid2 |
	uuid1 _ UUID new.
	uuid2 _ UUID new.
	self should: [uuid1 = uuid1].
	self should: [uuid2 = uuid2].
	self shouldnt: [uuid1 = uuid2].
	self shouldnt: [uuid1 hash = uuid2 hash].
