testBack
	"Test the new implemtation of the method back."
	|stream|
	stream := self streamOn: 'abc'.
	stream next: 2.
	self assert: stream back = $b.