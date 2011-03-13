testRemoveAllError
	"self debug: #testRemoveElementThatExists"
	| el res subCollection |
	el := self elementNotIn.
	subCollection := self nonEmptyWithoutEqualElements copyWith: el.
	self 
		should: [ res := self nonEmptyWithoutEqualElements removeAll: subCollection ]
		raise: Error