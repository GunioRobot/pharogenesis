nextPut: anObject
	"Write anObject to the receiver stream. Answer anObject.
	 NOTE: If anObject is a reference type (one that we write cross-references to) but its externalized form (result of objectToStoreOnDataStream) isnÕt (e.g. CompiledMethod and ViewState), then we should remember its externalized form
 but not add to ÔreferencesÕ. Putting that object again should just put its
 external form again. ThatÕs more compact and avoids seeks when reading.
 But we just do the simple thing here, allowing backward-references for
 non-reference types like nil. So objectAt: has to compensate. Objects that
 externalize nicely wonÕt contain the likes of ViewStates, so this shouldnÕt
 hurt much.
	 11/15/92 jhm: writeReference: -> errorWriteReference:."
	| typeID selector objectToStore |

	typeID _ self typeIDFor: anObject.
	(self tryToPutReference: anObject typeID: typeID)
		ifTrue: [^ anObject].

	(objectToStore _ anObject objectToStoreOnDataStream) == anObject
		ifFalse: [typeID _ self typeIDFor: objectToStore].

	byteStream nextPut: typeID.
	selector _ #(writeNil: writeTrue: writeFalse: writeInteger: 
		writeString: writeSymbol: writeByteArray:
		writeArray: writeInstance: errorWriteReference: writeBitmap:
		writeClass: writeUser: writeFloat:) at: typeID.
	self perform: selector with: objectToStore.

	^ anObject