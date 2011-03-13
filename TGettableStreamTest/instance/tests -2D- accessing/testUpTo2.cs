testUpTo2
	| returnValue stream |

	stream := self streamOnString.
	returnValue := stream upTo: $d.
	self assert: returnValue = 'abc'.
	self assert: stream peek = $e.