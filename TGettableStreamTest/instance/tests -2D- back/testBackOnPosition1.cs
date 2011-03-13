testBackOnPosition1
	"Test the new implemtation of the method back."
	|stream|
	stream := self streamOn: 'abc'.
	stream next.
	self assert: stream back = $a.