subdivideToBeMonoton: base inX: doTestX
	"Check if the given bezier curve is monoton in Y, and, if desired in X. 
	If not, subdivide it"
	| index1 index2 base2 |
	self inline: false.
	base2 _ index1 _ index2 _ self subdivideToBeMonotonInY: base.
	doTestX ifTrue:[index1 _ self subdivideToBeMonotonInX: base].
	index1 > index2 ifTrue:[index2 _ index1].
	(base ~= base2 and:[doTestX]) ifTrue:[index1 _ self subdivideToBeMonotonInX: base2].
	index1 > index2 ifTrue:[index2 _ index1].
	^index2