primitiveSomeObject
	"Return the first object in the heap."

	self pop: 1.
	self push: self firstAccessibleObject.