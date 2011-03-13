testAllImplementedMessagesWithout
	"self debug: #testAllImplementedMessagesWithout"

	self t6 compile: 'das2qwdqwd'.
	self assert: (SystemNavigation default allImplementedMessages includes: #das2qwdqwd).
	self deny: (SystemNavigation default allImplementedMessages includes: #qwdqwdqwdc).