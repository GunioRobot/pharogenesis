testInstanciationUsingOn
	"self debug: #testInstanciationUsingOn"
	| stream |
	stream := WriteStream on: #(1 2).
	stream nextPut: 3.
	self assert: stream contents = #(3)