next
	"Answer the next object in the stream."
	| type selector anObject isARefType |

	type _ byteStream next.
	isARefType _ self noteCurrentReference: type.
	selector _ #(readNil readTrue readFalse readInteger
			readString readSymbol readByteArray
			readArray readInstance readReference readBitmap
			readClass readUser readFloat) at: type.
	anObject _ self perform: selector. "A method that recursively
		calls next (readArray, readInstance, objectAt:) must save &
		restore the current reference position."
	isARefType ifTrue: [self beginReference: anObject].

	"After reading the externalObject, internalize it.
	 #readReference is a special case. Either:
	   (1) We actually have to read the object, recursively calling
		   next, which internalizes the object.
	   (2) We just read a reference to an object already read and
		   thus already interalized.
	 Either way, we must not re-internalize the object here."
	selector == #readReference ifFalse:
		[anObject _ self internalize: anObject.
		self checkForPaths: anObject].
	^ anObject