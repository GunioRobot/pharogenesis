restoreEndianness
	"Fix endianness (byte order) of any objects not already fixed.  Do this by discovering classes that need a startUp message sent to each instance, and sending it.
	I have just been brought in and converted to live objects.  Find all Sets and Dictionaries in the newly created objects and rehash them.  Segment is near then end of memory, since is was newly brought in (and a new object created for it).
	Also, collect all classes of receivers of blocks which refer to instance variables.  Return them.  Caller will check if they have been reshaped."

	| object sets receiverClasses inSeg noStartUpNeeded startUps cls msg |

	object _ segment.
	sets _ OrderedCollection new.
		"have to collect them, because Dictionary makes a copy, and that winds up at the end of memory and gets rehashed and makes another one."
	receiverClasses _ IdentitySet new.
	noStartUpNeeded _ IdentitySet new.	"classes that don't have a per-instance startUp message"
	startUps _ IdentityDictionary new.	"class -> MessageSend of a startUp message"
	inSeg _ true.
	[object _ object nextObject.  "all the way to the end of memory to catch remade objects"
		object == endMarker ifTrue: [inSeg _ false].	"off end"
		object isInMemory ifTrue: [
			(object isKindOf: Set) ifTrue: [sets add: object].
			(object isKindOf: ContextPart) ifTrue: [
				(inSeg and: [object hasInstVarRef]) ifTrue: [
					receiverClasses add: object receiver class]].
			inSeg ifTrue: [
				(noStartUpNeeded includes: object class) ifFalse: [
					cls _ object class.
					(msg _ startUps at: cls ifAbsent: [nil]) ifNil: [
						msg _ cls startUpFrom: self.	"a Message, if we need to swap bytes this time"
						msg ifNil: [noStartUpNeeded add: cls]
							ifNotNil: [startUps at: cls put: msg]].
					msg ifNotNil: [msg sentTo: object]]]]. 
		object == 0] whileFalse.
	sets do: [:each | each rehash].	"our purpose"
	^ receiverClasses	"our secondary job"
