testSetToEnd
	| stream |

	stream := self emptyStream.
	stream setToEnd.
	self assert: stream atEnd.
	
	stream := self streamOnArray.
	stream setToEnd.
	self assert: stream atEnd.
	stream position: 1.
	self deny: stream atEnd.
	stream setToEnd.
	self assert: stream atEnd.