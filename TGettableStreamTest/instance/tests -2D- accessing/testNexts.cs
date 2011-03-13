testNexts
	self assert: (self emptyStream next: 0) isEmpty.
	self assert: (self streamOnArray next: 0) isEmpty.
	self assert: (self streamOnArray next: 1) = #(1).
	self assert: (self streamOnArray next: 2) = #(1 #(a b c)).
	self assert: (self streamOnArray next: 3) = #(1 #(a b c) false).