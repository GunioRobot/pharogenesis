testPeek2
	| stream |
	stream := self streamOn: #(nil nil nil).
	
	self assert: stream peek isNil.
	stream next.
	self assert: stream peek isNil.
	stream next.
	self assert: stream peek isNil.
	stream next.
	
	"Yes, #peek answers nil when there is no more element to read."
	self assert: stream peek isNil.