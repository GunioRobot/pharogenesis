testPeekFor
	| stream |

	stream := self streamOnArray.
	self assert: (stream peekFor: 1).
	self assert: (stream peekFor: #(a b c)).
	self assert: (stream peekFor: false).

	stream := self streamOnArray.
	self deny: (stream peekFor: #(a b c)).
	self deny: (stream peekFor: false).
	self assert: (stream peekFor: 1).

	self deny: (stream peekFor: 1).
	self deny: (stream peekFor: false).
	self assert: (stream peekFor: #(a b c)).
	
	self deny: (stream peekFor: 1).
	self deny: (stream peekFor: #(a b c)).
	self assert: (stream peekFor: false).
	
	self assert: (stream atEnd).
	self deny: (stream peekFor: nil).
	self deny: (stream peekFor: 1).
	self deny: (stream peekFor: #(a b c)).
	self deny: (stream peekFor: false).