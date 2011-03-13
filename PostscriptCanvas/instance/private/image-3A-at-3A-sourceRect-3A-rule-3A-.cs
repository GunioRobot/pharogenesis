image: aForm at: aPoint sourceRect: sourceRect rule: rule 
	self preserveStateDuring:
		[:inner | inner translate: aPoint + self origin.
		target write: aForm]
