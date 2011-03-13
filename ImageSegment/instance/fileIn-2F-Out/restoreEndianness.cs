restoreEndianness
	"Fix endianness (byte order) of any objects not already fixed.
	I have just been brought in and converted to live objects.  Find all Sets and Dictionaries in the newly created objects and rehash them.  Segment is near then end of memory, since is was newly brought in (and a new object created for it).
	Also, collect all classes of receivers of blocks which refer to instance variables.  Return them.  Caller will check if they have been reshaped."

	| object sets receiverClasses inSeg reorder |

	object _ segment.
	sets _ OrderedCollection new.
		"have to collect them, because Dictionary makes a copy, and that winds up at the end of memory and gets rehashed and makes another one."
	receiverClasses _ IdentitySet new.
	reorder _ (Smalltalk endianness) ~~ 
		((segment first bitShift: -24) asCharacter == $d ifTrue: [#big] ifFalse: [#little]).
	inSeg _ true.
	[object _ object nextObject.  "all the way to the end of memory to catch remade objects"
		object == endMarker ifTrue: [inSeg _ false].	"off end"
		object isInMemory ifTrue: [
			(object isKindOf: Set) ifTrue: [sets add: object].
			(object isKindOf: ContextPart) ifTrue: [
				(inSeg and: [object hasInstVarRef]) ifTrue: [
					receiverClasses add: object receiver class
				]
			].	
			(reorder and: [(object class == SoundBuffer) & inSeg]) ifTrue: [object swapHalves]]. 
		object == 0] whileFalse.
	sets do: [:each | each rehash].	"our purpose"
	^ receiverClasses	"our secondary job"
