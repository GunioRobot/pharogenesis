outputReference: referencePosn
	"PRIVATE -- Output a reference to the object at integer stream position
	 referencePosn. To output a weak reference to an object not yet written, supply
	 (self vacantRef) for referencePosn. -- 11/15/92 jhm"

	byteStream nextPut: 10. "reference typeID"
	byteStream nextNumber: 4 put: referencePosn