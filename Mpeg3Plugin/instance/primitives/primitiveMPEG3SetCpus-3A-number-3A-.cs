primitiveMPEG3SetCpus: fileHandle number: cpus
	| file |

	"int mpeg3_set_cpus(mpeg3_t *file, int cpus)"
	self var: #file declareC: 'mpeg3_t * file'.
	self primitive: 'primitiveMPEG3SetCpus'
		parameters: #(Oop SmallInteger).
	file _ self mpeg3tValueOf: fileHandle.
	cpus < 0 ifTrue: [interpreterProxy success: false. ^nil].
	file = nil ifTrue: [^nil].
	self cCode: 'mpeg3_set_cpus(file,cpus)'.
