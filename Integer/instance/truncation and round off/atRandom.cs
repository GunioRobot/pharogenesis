atRandom
	"Answer a random integer from 1 to self.  This implementation uses a
	shared generator. Heavy users should their own implementation or use
	Interval>atRandom: directly."

	^ self atRandom: Collection randomForPicking