testTAddIfNotPresentWithElementAlreadyIn

	| added oldSize collection element |
	collection := self collectionWithElement .
	oldSize := collection size.
	element := self element .
	self assert: (collection  includes: element ).
	
	added := collection  addIfNotPresent: element .
	
	self assert: added == element .	"test for identiy because #add: has not reason to copy its parameter."
	self assert: collection  size = oldSize