primitiveMPEG3SetSample: fileHandle sample: aSampleNumber stream: aNumber
	| file result |

	"int mpeg3_set_sample(mpeg3_t *file, long sample, int stream)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3SetSample'
		parameters: #(Oop Float SmallInteger).

	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^0].
	aNumber < 0 ifTrue: [interpreterProxy success: false. ^nil].
	aNumber >= (self cCode: 'result = mpeg3_total_astreams(file)') ifTrue: [
		interpreterProxy success: false.  ^0 ].


	aSampleNumber < 0 ifTrue: [interpreterProxy success: false. ^nil].
	self cCode: 'result = mpeg3_set_sample(file,aSampleNumber,aNumber)'.
	^result asSmallIntegerObj
