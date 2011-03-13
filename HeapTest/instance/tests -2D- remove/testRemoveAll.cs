testRemoveAll
	"self debug: #testRemoveElementThatExists"
	| el res subCollection collection |
	collection := self nonEmptyWithoutEqualElements.
	el := collection anyOne.
	subCollection := collection copyWithout: el.
	self 
		shouldnt: [ res := collection removeAll: subCollection ]
		raise: Error.
	self assert: collection size = 1.
	self nonEmptyWithoutEqualElements do: [ :each | self assert: each = el ]