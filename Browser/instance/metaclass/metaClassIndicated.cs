metaClassIndicated
	"Answer the boolean flag that indicates which of the method dictionaries, 
	class or metaclass."

	^ metaClassIndicated and: [self classCommentIndicated not]