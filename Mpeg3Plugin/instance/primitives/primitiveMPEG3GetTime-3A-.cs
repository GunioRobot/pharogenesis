primitiveMPEG3GetTime: fileHandle 
	| file result |

	"double mpeg3_get_time(mpeg3_t *file)"
	self var: # result declareC: 'double result'.
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3GetTime'
		parameters: #(Oop).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^nil].
	self cCode: 'result = mpeg3_get_time(file)'.
	^result asOop: Float.
