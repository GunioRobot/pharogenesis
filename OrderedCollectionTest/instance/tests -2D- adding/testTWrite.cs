testTWrite
	| added collection element |
	collection := self otherCollection  .
	element := self element .
	added := collection  write: element .
	
	self assert: added == element .	"test for identiy because #add: has not reason to copy its parameter."
	self assert: (collection  includes: element )	.
	self assert: (collection  includes: element ).
	
	