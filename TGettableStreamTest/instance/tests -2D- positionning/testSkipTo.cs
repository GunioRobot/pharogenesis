testSkipTo
	| stream |
	stream := self emptyStream.
	self deny: (stream skipTo: nil).
	
	stream := self streamOnArray.
	self deny: stream atEnd.
	self deny: (stream skipTo: nil).
	self assert: stream atEnd.
	
	stream := self streamOnArray.
	self assert: stream peek = 1.
	self assert: (stream skipTo: #(a b c)).
	self assert: stream peek = false.
	self assert: (stream skipTo: false).
	self assert: stream atEnd.