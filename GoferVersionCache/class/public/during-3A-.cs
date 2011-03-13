during: aBlock
	| cache |
	cache := Dictionary new.
	^ aBlock 
		on: self 
		do: [ :notification | notification resume: cache ]