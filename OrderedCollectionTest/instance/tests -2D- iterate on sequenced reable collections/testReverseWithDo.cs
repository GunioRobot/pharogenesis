testReverseWithDo
		
	| secondCollection result index |
	result:= OrderedCollection new.
	index := self nonEmptyMoreThan1Element size + 1.
	secondCollection:= self nonEmptyMoreThan1Element  copy.
	
	self nonEmptyMoreThan1Element  reverseWith: secondCollection do:
		[:a :b |
		self assert: (self nonEmptyMoreThan1Element indexOf: a  ) = (index := index - 1 ).
		result add: (a = b)].
	
	1 to: result size do:
		[:i|
		self assert: (result at:i)=(true)].
	self assert: result size =  self nonEmptyMoreThan1Element size.