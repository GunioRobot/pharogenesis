testTWriteTwice
	| added oldSize collection element |
	collection := self collectionWithElement .
	element := self element .
	oldSize := collection  size.
	added := collection 
		write: element ;
		write: element .
	self assert: added == element .	"test for identiy because #add: has not reason to copy its parameter."
	self assert: (collection  includes: element ).
	self assert: collection  size = (oldSize + 2)