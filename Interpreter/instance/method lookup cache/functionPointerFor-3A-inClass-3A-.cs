functionPointerFor: primIdx inClass: theClass
"find an actual function pointer for this primitiveIndex - this is an opportunity to specialise the prim for the relevant class (format for example).
Default for now is simply the entry in the base primitiveTable"
	^self cCoerce: (primitiveTable at: primIdx) to:'int'