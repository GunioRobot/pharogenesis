cancelOutOfPainting
	self delete.
	dimForm delete.
	emptyPicBlock value.	"note no args to block!"
	hostView changed.
	^ nil	"Tell them we cancelled"