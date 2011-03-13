rehashSets
	"I have just been brought in and converted to live objects.  Find all Sets and Dictionaries in the newly created objects and rehash them.  Segment is near then end of memory, since is was newly brought in (and a new object created for it).
	Also, collect all classes of receivers of blocks.  Return them.  Caller will check if they have been reshaped."

	| object sets receiverClasses inSeg |
	object := segment.
	sets := OrderedCollection new.
		"have to collect them, because Dictionary makes a copy, and that winds up at the end of memory and gets rehashed and makes another one."
	receiverClasses := IdentitySet new.
	inSeg := true.
	[object := object nextObject.  
		object == endMarker ifTrue: [inSeg := false].	"off end"
		object isInMemory ifTrue: [
			(object isKindOf: Set) ifTrue: [sets add: object].
			object isBlock ifTrue: [inSeg ifTrue: [
					receiverClasses add: object receiver class]].	
			object class == MethodContext ifTrue: [inSeg ifTrue: [
					receiverClasses add: object receiver class]].	
			]. 
		object == 0] whileFalse.
	sets do: [:each | each rehash].	"our purpose"
	^ receiverClasses	"our secondary job"
