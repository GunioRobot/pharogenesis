primitiveGetMacintoshFileTypeAndCreatorFrom: aFileName
	| oop ptr keyLength creator |

	self primitive: 'primitiveGetMacintoshFileTypeAndCreatorFrom'
		parameters: #(String).
	self var: #aFile declareC: 'char aFile[256]'.
	self var: #creator declareC: 'char creator[8]'.
	self var: #ptr type: 'char *'.
	
	keyLength _ interpreterProxy byteSizeOf: aFileName cPtrAsOop.
	self sqInternetGetMacintoshFileTypeAndCreatorFrom: aFileName keySize: keyLength into: creator.
	oop _ interpreterProxy instantiateClass: interpreterProxy classString indexableSize: 8.
	ptr _ interpreterProxy firstIndexableField: oop.
	0 to: 7 do:[:i|
		ptr at: i put: (creator at: i)].
	^oop.
