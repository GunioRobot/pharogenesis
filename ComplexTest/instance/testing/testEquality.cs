testEquality
	"self run: #testEquality"
	"self debug: #testEquality"
	
	self assert: 0i = 0.
	self assert: (2 - 5i) = ((1 -4 i) + (1 - 1i)).
	self assert: 0i isZero.
	self deny: (1 + 3 i) = 1.
	self deny: (1 + 3 i) = (1 + 2i).