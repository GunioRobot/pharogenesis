serviceCompressFile

	^ FileModifyingSimpleServiceEntry 
				provider: self 
				label: 'compress file'
				selector: #compressFile:
				description: 'compress file using gzip compression, making a new file'