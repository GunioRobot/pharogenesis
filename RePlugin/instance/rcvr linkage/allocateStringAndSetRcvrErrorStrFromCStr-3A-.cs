allocateStringAndSetRcvrErrorStrFromCStr: aCStrBuffer

	|length errorStrObj errorStrObjPtr |
	self var: #aCStrBuffer declareC: 'const char *aCStrBuffer'.
	self var: #errorStrObjPtr declareC: 'void *errorStrObjPtr'.
	"Allocate errorStrObj"
	length _ self cCode: 'strlen(aCStrBuffer)'.
	errorStrObj _ interpreterProxy
				instantiateClass: (interpreterProxy classString) 
				indexableSize: length.
	self loadRcvrFromStackAt: 0. "Assume garbage collection after instantiation"

	"Copy aCStrBuffer to errorStrObj's buffer"
	errorStrObjPtr _ interpreterProxy arrayValueOf: errorStrObj.	
	self cCode:'memcpy(errorStrObjPtr,aCStrBuffer,length)'.
	self touch: errorStrObjPtr; touch: errorStrObj.
	"Set rcvrErrorStr from errorStrObj and Return"
	self rcvrErrorStrFrom: errorStrObj.
	^errorStrObj.