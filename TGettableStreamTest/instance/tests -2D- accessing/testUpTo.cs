testUpTo
	| returnValue stream |
	returnValue := (self emptyStream upTo: nil).
	self assert: returnValue isCollection.
	self assert: returnValue isEmpty.
	
	stream := self streamOnArray.
	returnValue := stream upTo: #(a b c).
	self assert: returnValue = #(1).
	self assert: stream peek = false.
	
	stream := self streamOnArray.
	returnValue := stream upTo: true.
	self assert: returnValue = #(1 #(a b c) false).
	self assert: stream atEnd.