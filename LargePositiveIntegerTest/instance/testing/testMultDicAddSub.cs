testMultDicAddSub
	| n f f1 |
	
	n _ 100.
	f _ 100 factorial.
	f1 _ f*(n+1).
	n timesRepeat: [f1 _ f1 - f].
	self should: [f1 = f]. 

	n timesRepeat: [f1 _ f1 + f].
	self should: [f1 // f = (n+1)]. 
	self should: [f1 negated = (Number readFrom: '-' , f1 printString)].