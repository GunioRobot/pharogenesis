serviceOpenTrueTypeFont

	^ SimpleServiceEntry 
				provider: self 
				label: 'open true type font'
				selector: #openTTFFile:
				description: 'open true type font'