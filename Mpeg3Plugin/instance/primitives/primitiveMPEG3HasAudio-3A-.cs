primitiveMPEG3HasAudio: fileHandle
	| file result |

	"int mpeg3_has_audio(mpeg3_t *file)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3HasAudio'
		parameters: #(Oop).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^nil].
	self cCode: 'result = mpeg3_has_audio(file)'.
	^result asOop: Boolean
