testUpToAll
	"just a test to exercise changed method"
	self assert: (stream1 upToAll:  '12345678') =''.
	