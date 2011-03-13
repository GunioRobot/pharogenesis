collectWithIndex: aBlock 
	"Just like collect: except that an index is supplied along with the object
	in the collection.  Be sure to use a block that expects two arguments.
		#(5 2 1 4 3) collectWithIndex: [:each :index | (each - index) abs].   "

	| aStream index length |
	aStream _ WriteStream on: (self species new: self size).
	index _ 0.
	length _ self size.
	[(index _ index + 1) <= length]
		whileTrue: [aStream nextPut: (aBlock value: (self at: index) value: index)].
	^aStream contents