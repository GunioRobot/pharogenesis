isPointers: oop
	"Answer true if the argument has only fields that can hold oops. See comment in formatOf:"

	^ (self formatOf: oop) <= 4