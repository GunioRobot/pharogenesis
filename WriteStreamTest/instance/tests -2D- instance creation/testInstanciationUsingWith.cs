testInstanciationUsingWith
	"self debug: #testInstanciationUsingWith"
	| stream |
	stream := WriteStream with: #(1 2).
	stream nextPut: 3.
	self assert: stream contents = #(1 2 3)