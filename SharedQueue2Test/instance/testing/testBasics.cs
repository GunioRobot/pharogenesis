testBasics
	| q |
	q := SharedQueue2 new.

	self should: [ q nextOrNil = nil ].

	q nextPut: 5.
	self should: [ q nextOrNil = 5 ].
	self should: [ q nextOrNil = nil ].

