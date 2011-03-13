collect: aBlock 
	"Return a Set containing the result of evaluating aBlock
	for each element of this set"
	| newSet |
	tally = 0 ifTrue: [^ Set new: 2].
	newSet _ Set new: self size.
	array do:
		[:element |
		element == nil ifFalse: [newSet add: (aBlock value: element)]].
	^ newSet