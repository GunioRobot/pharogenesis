primitiveMPEG3VideoHeight: fileHandle stream: aNumber
	| file result |

	"int mpeg3_video_height(mpeg3_t *file,int stream)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3VideoHeight'
		parameters: #(Oop SmallInteger).

	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^0].
	aNumber < 0 ifTrue: [interpreterProxy success: false. ^nil].
	aNumber >= (self cCode: 'result = mpeg3_total_vstreams(file)') ifTrue: [
		interpreterProxy success: false.  ^0 ].


	self cCode: 'result = mpeg3_video_height(file,aNumber)'.
	^result asSmallIntegerObj
