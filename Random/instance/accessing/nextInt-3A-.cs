nextInt: anInteger
	"Answer a random integer in the interval [1, anInteger]."

	^ (self next * anInteger) truncated + 1