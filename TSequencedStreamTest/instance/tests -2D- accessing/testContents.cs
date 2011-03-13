testContents
	| stream |
	self assert: self emptyStream contents = ''.
	
	stream := self streamOnArray.
	self assert: stream contents = #(1 #(a b c) false).
	stream position: 3.
	self assert: stream contents = #(1 #(a b c) false).
	
	stream := self streamOnString.
	self assert: stream contents = 'abcde'.
	stream setToEnd.
	self assert: stream contents = 'abcde'.