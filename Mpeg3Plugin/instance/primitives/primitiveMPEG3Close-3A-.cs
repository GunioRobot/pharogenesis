primitiveMPEG3Close: fileHandle
	| file index |

	"int mpeg3_close(mpeg3_t *file)"
	self var: #file declareC: 'mpeg3_t * file'.
	self var: #index declareC: 'mpeg3_t ** index'.
	self primitive: 'primitiveMPEG3Close'
		parameters: #(Oop).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^nil].
	self cCode: 'removeFileEntry(file); mpeg3_close(file)'.
	index _ self cCoerce: (interpreterProxy firstIndexableField: fileHandle)
						to: 'mpeg3_t **'.
	self cCode: '*index = 0'.
