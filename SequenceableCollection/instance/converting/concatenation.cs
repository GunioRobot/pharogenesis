concatenation
	|result index|

	result _ Array new: (self inject: 0 into: [:sum :each | sum + each size]).
	index _ 0.
	self do: [:each | each do: [:item | result at: (index _ index+1) put: item]].
	^result