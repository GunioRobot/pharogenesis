cancelOutOfPainting
	self deleteSelfAndSubordinates.
	emptyPicBlock ifNotNil: [emptyPicBlock value].	"note no args to block!"
	hostView ifNotNil: [hostView changed].
	^ nil