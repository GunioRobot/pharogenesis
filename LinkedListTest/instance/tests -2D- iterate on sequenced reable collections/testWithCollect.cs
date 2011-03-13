testWithCollect
	
	| result newCollection index collection |

	index := 0.
	collection := self nonEmptyMoreThan1Element .
	newCollection := collection  copy.
	result:=collection   with: newCollection collect: [:a :b | 
		self assert: (collection  indexOf: a ) = ( index := index + 1).
		self assert: (a = b).
		b].
	
	1 to: result size do:[: i | self assert: (result at:i)= (collection  at: i)].
	self assert: result size = collection  size.