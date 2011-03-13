mixSampleCount: count into: aSoundBuffer startingAt: index pan: pan
	"Mix the given number of samples with the samples already in the given buffer starting at the given index. Assume that the buffer size is at least (index + count) - 1. The pan parameter determines the left-right balance of the sound, where 0 is left only, 1000 is right only, and 500 is centered."

	self subclassResponsibility.