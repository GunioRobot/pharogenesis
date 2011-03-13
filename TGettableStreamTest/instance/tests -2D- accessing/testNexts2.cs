testNexts2

	| stream |
	stream := self streamOnArray.
	self assert: (stream next: 2) = #(1 #(a b c)).
	self assert: (stream next: 1) = #(false).