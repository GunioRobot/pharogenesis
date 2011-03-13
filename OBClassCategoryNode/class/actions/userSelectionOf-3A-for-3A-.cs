userSelectionOf: classNames for: toMatch 
	| exactMatch labels lines |
	exactMatch := classNames detect: [:ea | ea asLowercase = toMatch] ifNone: [nil].
	exactMatch 
		ifNil: [labels _ classNames. lines _ #()]
		ifNotNil: [labels _ classNames copyWithFirst: exactMatch. lines _ #(1)].
	^ OBChoiceRequest labels: labels lines: lines.