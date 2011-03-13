testSkipTo2
	| stream |
	
	stream := self streamOnString.
	self assert: (stream skipTo: $b).
	self assert: stream peek = $c.
	self assert: (stream skipTo: $d).
	self assert: stream peek = $e.
	self assert: (stream skipTo: $e).
	self assert: stream atEnd.