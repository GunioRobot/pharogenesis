romanNumber
	| value v1 v2 |
	value _ v1 _ v2 _ 0.
	self reverseDo:
		[:each |
		v1 _ #(1 5 10 50 100 500 1000) at: ('IVXLCDM' indexOf: each).
		v1 >= v2
			ifTrue: [value _ value + v1]
			ifFalse: [value _ value - v1].
		v2 _ v1].
	^ value