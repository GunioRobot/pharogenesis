testAllSentMessages
	"self debug: #testAllSentMessages"

	self t1 compile: 'foo 1 dasoia'.
	self assert: (SystemNavigation default allSentMessages includes: 'dasoia' asSymbol).
	self deny: (SystemNavigation default allSentMessages includes: 'nioaosi' asSymbol).