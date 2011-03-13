testReset
	| stream |

	stream := self emptyStream.
	stream reset.
	self assert: stream position = 0.
	
	stream := self streamOnArray.
	stream reset.
	self assert: stream position = 0.
	self deny: stream atEnd.
	stream position: 3.
	self assert: stream atEnd.
	stream reset.
	self assert: stream position = 0.