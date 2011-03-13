testNext
	|stream|

	stream := self streamOnArray.
	self assert: stream next = 1.
	self assert: stream next = #(a b c).
	self assert: stream next = false.
	
	stream := self streamOnString.
	self assert: stream next = $a.
	self assert: stream next = $b.
	self assert: stream next = $c.
	self assert: stream next = $d.
	self assert: stream next = $e.
	