testOldBack
	"Test the old behavior of the method back. The method #oldBack is a misconception about what a stream is. A stream contains a pointer *between* elements with past and future elements. The method #oldBack considers that the pointer is *on* an element. (Damien Cassou - 1 August 2007)"
	|stream|
	stream := self streamOn: 'abc'.
	stream next: 2.
	self assert: stream oldBack = $a.