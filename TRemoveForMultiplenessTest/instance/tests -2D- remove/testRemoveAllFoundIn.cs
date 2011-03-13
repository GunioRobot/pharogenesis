testRemoveAllFoundIn
	"self debug: #testRemoveElementThatExists"
	| el res subCollection |
	el := self nonEmptyWithoutEqualElements anyOne.
	subCollection := (self nonEmptyWithoutEqualElements copyWithout: el) copyWith: self elementNotIn.
	self 
		shouldnt: 
			[ res := self nonEmptyWithoutEqualElements removeAllFoundIn: subCollection ]
		raise: Error.
	self assert: self nonEmptyWithoutEqualElements size = 1.
	self nonEmptyWithoutEqualElements do: [ :each | self assert: each = el ]