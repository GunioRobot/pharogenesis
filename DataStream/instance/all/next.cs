next
	"Answer the next object in the stream."
	| type selector anObject isARefType pos |

	type _ byteStream next.
	type ifNil: [pos _ byteStream position.	"absolute!!"
		byteStream close.	"clean up"
		byteStream position = 0 
			ifTrue: [self error: 'The file did not exist in this directory'] 
			ifFalse: [self error: 'Unexpected end of object file'].
		pos.	"so can see it in debugger"
		^ nil].
	type = 0 ifTrue: [pos _ byteStream position.	"absolute!!"
		byteStream close.	"clean up"
		self error: 'Expected start of object, but found 0'.
		^ nil].
	isARefType _ self noteCurrentReference: type.
	selector _ #(readNil readTrue readFalse readInteger
			readString readSymbol readByteArray
			readArray readInstance readReference readBitmap
			readClass readUser readFloat readRectangle readShortInst) at: type.
	anObject _ self perform: selector. "A method that recursively
		calls next (readArray, readInstance, objectAt:) must save &
		restore the current reference position."
	false ifTrue: ["So Senders will find the perform: here"
			self readNil; readTrue; readFalse; readInteger;
			readString; readSymbol; readByteArray;
			readArray; readInstance; readReference; readBitmap;
			readClass; readUser; readFloat; readRectangle; readShortInst].
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