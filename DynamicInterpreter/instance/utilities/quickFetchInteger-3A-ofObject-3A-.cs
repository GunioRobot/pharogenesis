quickFetchInteger: fieldIndex ofObject: objectPointer
	"Return the integer value of the field without verifying that it is an integer value! For use in time-critical places where the integer-ness of the field can be guaranteed."

	^ self integerValueOf:
		(self fetchPointer: fieldIndex ofObject: objectPointer).