primitiveMPEG3PreviousFrame: fileHandle stream: aNumber
	| file result |

	"int mpeg3_previous_frame(mpeg3_t *file, int stream)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3PreviousFrame'
		parameters: #(Oop SmallInteger).

	file _ self mpeg3tValueOf: fileHandle.
	aNumber < 0 ifTrue: [interpreterProxy success: false. ^nil].
	file = nil ifTrue: [^nil].
	aNumber >= (self cCode: 'result = mpeg3_total_vstreams(file)') ifTrue: [
		interpreterProxy success: false.  ^0 ].


	self cCode: 'result = mpeg3_previous_frame(file,aNumber)'.
	^result asSmallIntegerObj
