testPosition
	| stream |
	self assert: self emptyStream position isZero.
	
	stream := self streamOnArray.
	self assert: stream position = 0.
	stream next.
	self assert: stream position = 1.
	stream next.
	self assert: stream position = 2.
	stream next.
	self assert: stream position = 3.
	stream next.
	self assert: stream position = 3.
	stream next.
	self assert: stream position = 3.