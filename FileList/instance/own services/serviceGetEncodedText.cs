serviceGetEncodedText

	^  (SimpleServiceEntry 
			provider: self 
			label: 'view as encoded text'
			selector: #getEncodedText
			description: 'view as encoded text')

