primitiveMPEG3Open: path
	| mpeg3Oop index sz storage |

	"mpeg3_t* mpeg3_open(char *path)"
	self var: #index declareC: 'mpeg3_t ** index'.
	self var: #storage declareC: 'char storage[1024]'.
	self primitive: 'primitiveMPEG3Open'
		parameters: #(String).
	sz _ interpreterProxy byteSizeOf: path cPtrAsOop.
	self cCode: 'strncpy(storage,path,sz)'.
	storage at: sz put: 0.
	mpeg3Oop _ interpreterProxy instantiateClass: interpreterProxy classByteArray
					indexableSize: 4.	
	index _ self cCoerce: (interpreterProxy firstIndexableField: mpeg3Oop)
						to: 'mpeg3_t **'.
	self cCode: '*index = mpeg3_open(storage); makeFileEntry(*index)'.
	^mpeg3Oop.
