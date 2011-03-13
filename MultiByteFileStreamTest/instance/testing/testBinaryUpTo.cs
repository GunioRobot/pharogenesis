testBinaryUpTo
	"This is a non regression test for bug http://bugs.squeak.org/view.php?id=6933"
	
	| foo |
	
	foo := MultiByteFileStream forceNewFileNamed: 'foobug6933'.
	[foo binary.
	foo nextPutAll: #(1 2 3 4) asByteArray] ensure: [foo close].

	foo := MultiByteFileStream oldFileNamed: 'foobug6933'.
	[foo binary.
	self assert: (foo upTo: 3) = #(1 2 ) asByteArray] ensure: [foo close]