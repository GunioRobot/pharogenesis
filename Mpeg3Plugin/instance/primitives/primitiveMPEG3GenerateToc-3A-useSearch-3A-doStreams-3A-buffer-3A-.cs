primitiveMPEG3GenerateToc: fileHandle useSearch: timecode doStreams: streams buffer: aString
	| file bufferSize |

	"int mpeg3_generate_toc_for_Squeak(FILE *output, char *path, int timecode_search, int print_streams, char *buffer)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3GenerateToc'
		parameters: #(Oop SmallInteger Boolean  String).
	file _ self mpeg3tValueOf: fileHandle.
	file = nil ifTrue: [^nil].
	bufferSize _ interpreterProxy slotSizeOf: (interpreterProxy stackValue: 0).
	self cCode: 'mpeg3_generate_toc_for_Squeak(file,timecode,streams,aString,bufferSize)'.
