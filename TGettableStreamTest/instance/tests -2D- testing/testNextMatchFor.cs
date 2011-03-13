testNextMatchFor
	| stream |
	stream := self streamOnArray.
	self assert: (stream nextMatchFor: 1).
	self assert: (stream nextMatchFor: #(a b c)).
	self assert: (stream nextMatchFor: false).
	
	stream := self streamOnArray.
	self deny: (stream nextMatchFor: false).
	self assert: (stream nextMatchFor: #(a b c)).
	self assert: (stream nextMatchFor: false).
