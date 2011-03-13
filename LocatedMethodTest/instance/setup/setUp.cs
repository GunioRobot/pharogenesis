setUp
	super setUp.
	self t1 compile: '+ aNumber ^aNumber + 17'.
	self t1 compile: '!aNumber
		| temp |
		^aNumber + 17'.
	self t1 compile: '&& anObject'.
	self t1 compile: '@%+anObject'.
	self t1 compile: 'mySelector "a comment"'.
	self t1 compile: 'mySelector: something
		^17'.
	self t1 compile: 'mySelector: something and:somethingElse ^true'