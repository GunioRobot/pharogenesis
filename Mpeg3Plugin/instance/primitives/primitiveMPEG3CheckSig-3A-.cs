primitiveMPEG3CheckSig: path
	| result sz storage |

	"int mpeg3_check_sig(char *path)"
	self var: #storage declareC: 'char storage[1024] '.
	self primitive: 'primitiveMPEG3CheckSig'
		parameters: #(String).
	sz _ interpreterProxy byteSizeOf: path cPtrAsOop.
	self cCode: 'strncpy(storage,path,sz)'.
	storage at: sz put: 0.
	self cCode: 'result = mpeg3_check_sig(storage)'.
	^result asOop: Boolean
