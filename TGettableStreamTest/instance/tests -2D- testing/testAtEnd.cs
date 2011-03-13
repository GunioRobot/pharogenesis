testAtEnd
	| stream |
	self assert: self emptyStream atEnd.

	stream := self streamOnArray.
	self deny: stream atEnd.
	stream next: 3.
	self assert: stream atEnd.