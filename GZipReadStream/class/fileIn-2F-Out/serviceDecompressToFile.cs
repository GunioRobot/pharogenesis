serviceDecompressToFile

	^ FileModifyingSimpleServiceEntry 
				provider: self 
				label: 'decompress to file'
				selector: #saveContents:
				description: 'decompress to file'