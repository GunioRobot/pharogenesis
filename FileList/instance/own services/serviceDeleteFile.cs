serviceDeleteFile

	^ (SimpleServiceEntry provider: self label: 'delete' selector: #deleteFile)
			description: 'delete the seleted item'