primitiveMPEG3HasVideo: fileHandle
	| file result |

	"int mpeg3_has_video(mpeg3_t *file)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3HasVideo'
		parameters: #(Oop).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^nil].
	self cCode: 'result = mpeg3_has_video(file)'.
	^result asOop: Boolean
