addObject: anSMObject 
	"Add a new object, only if not already added."

	(self object: anSMObject id) ifNil: [
		self transaction: [self newObject: anSMObject]]