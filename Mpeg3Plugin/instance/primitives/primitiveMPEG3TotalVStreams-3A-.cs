primitiveMPEG3TotalVStreams: fileHandle
	| file result |

	"int mpeg3_total_vstreams(mpeg3_t *file)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3TotalVStreams'
		parameters: #(Oop).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^nil].
	self cCode: 'result = mpeg3_total_vstreams(file)'.
	^result asSmallIntegerObj
