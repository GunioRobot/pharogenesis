nextPut: anObject
	"Write anObject to the receiver stream. Answer anObject."
	| typeID selector objectToStore |

	typeID _ self typeIDFor: anObject.
	(self tryToPutReference: anObject typeID: typeID)
		ifTrue: [^ anObject].

	objectToStore _ (self objectIfBlocked: anObject) objectForDataStream: self.
	objectToStore == anObject ifFalse: [typeID _ self typeIDFor: objectToStore].

	byteStream nextPut: typeID.
	selector _ #(writeNil: writeTrue: writeFalse: writeInteger: 
		writeStringOld: writeSymbol: writeByteArray:
		writeArray: writeInstance: errorWriteReference: writeBitmap:
		writeClass: writeUser: writeFloat: writeRectangle: == "dummy 16" 
		writeString: writeBitmap: writeBitmap: writeWordLike:) at: typeID.
	self perform: selector with: objectToStore.

	^ anObject


"NOTE: If anObject is a reference type (one that we write cross-references to) but its externalized form (result of objectForDataStream:) isn't (e.g. CompiledMethod and ViewState), then we should remember its externalized form
 but not add to 'references'. Putting that object again should just put its
 external form again. That's more compact and avoids seeks when reading.
 But we just do the simple thing here, allowing backward-references for
 non-reference types like nil. So objectAt: has to compensate. Objects that
 externalize nicely won't contain the likes of ViewStates, so this shouldn't
 hurt much.
	 writeReference: -> errorWriteReference:."