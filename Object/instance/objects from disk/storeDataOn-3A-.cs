storeDataOn: aDataStream
	"Store myself on a DataStream. Answer self.  This is a low-level DataStream/ReferenceStream method. See also objectToStoreOnDataStream.
	 NOTE: This method must send 'aDataStream beginInstance:size:'
		and then put a number of objects (via aDataStream nextPut:/nextPutWeak:).
	 Cf. readDataFrom:size:, which must read back what this puts
	when given the size that it gave to beginInstance:size:. -- 11/15/92 jhm"
	| cntInstVars cntIndexedVars |

	cntInstVars _ self class instSize.
	cntIndexedVars _ self basicSize.
	aDataStream
		beginInstance: self class
		size: cntInstVars + cntIndexedVars.
	1 to: cntInstVars do:
		[:i | aDataStream nextPut: (self instVarAt: i)].
	1 to: cntIndexedVars do:
		[:i | aDataStream nextPut: (self basicAt: i)]