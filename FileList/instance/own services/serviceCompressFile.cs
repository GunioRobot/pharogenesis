serviceCompressFile
	"Answer a service for compressing a file"

	^ SimpleServiceEntry provider: self label: 'compress' selector: #compressFile description: 'compress file' buttonLabel: 'compress'