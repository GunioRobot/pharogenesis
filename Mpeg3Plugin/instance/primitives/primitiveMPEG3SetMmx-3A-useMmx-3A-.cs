primitiveMPEG3SetMmx: fileHandle useMmx: mmx
	| file |

	"int mpeg3_set_mmx(mpeg3_t *file, int use_mmx)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3SetMmx'
		parameters: #(Oop Boolean).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^nil].
	self cCode: 'mpeg3_set_mmx(file,mmx)'.
