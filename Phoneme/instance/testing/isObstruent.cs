isObstruent
	"Answer true if the receiver is an obstruent phoneme."
	^ self isStop or: [self isFricative or: [self isAffricate]]