deleteObjectWithId: anIdString
	"Delete an object. Polymorphic message."

	^(self objectWithId: anIdString) delete
