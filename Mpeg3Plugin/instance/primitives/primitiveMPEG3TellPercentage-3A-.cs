primitiveMPEG3TellPercentage: fileHandle
	| file result |

	"double mpeg3_tell_percentage(mpeg3_t *file)"
	self var: # result declareC: 'double result'.
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3TellPercentage'
		parameters: #(Oop).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^nil].
	self cCode: 'result = mpeg3_tell_percentage(file)'.
	^result asOop: Float.
