isAReferenceType: typeID
	"Return true iff typeID is one of the classes that can be written as a reference to an instance elsewhere in the stream. -- jhm, 8/9/96 tk"

	"too bad we can't put Booleans in an Array literal"
	^ (RefTypes at: typeID) == 1