primitiveMPEG3TotalAStreams: fileHandle
	| file result |

	"int mpeg3_total_astreams(mpeg3_t *file)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3TotalAStreams'
		parameters: #(Oop).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^0].
	self cCode: 'result = mpeg3_total_astreams(file)'.
	^result asSmallIntegerObj
