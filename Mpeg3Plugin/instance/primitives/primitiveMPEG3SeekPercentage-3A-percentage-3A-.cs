primitiveMPEG3SeekPercentage: fileHandle percentage: aNumber
	| file result |

	"int mpeg3_seek_percentage(mpeg3_t *file, double percentage)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3SeekPercentage'
		parameters: #(Oop Float).
	file _ self mpeg3tValueOf: fileHandle.
	aNumber < 0.0 ifTrue: [interpreterProxy success: false. ^nil].
	aNumber > 1.0 ifTrue: [interpreterProxy success: false. ^nil].
	file = nil ifTrue: [^nil].
	self cCode: 'result = mpeg3_seek_percentage(file,aNumber)'.
	^result asSmallIntegerObj
