readFrom: aFileName
	| savedCategorizer file |
	file _ FileStream fileNamed: aFileName.
	savedCategorizer _ self newCategorizer readFrom: file elementReader: [:s | s nextInt32]; yourself.
	file close.
	^ savedCategorizer