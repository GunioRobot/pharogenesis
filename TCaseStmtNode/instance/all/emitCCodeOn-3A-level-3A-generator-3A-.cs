emitCCodeOn: aStream level: level generator: aCodeGen

	| indent |
	indent _ (String new: level) collect: [ :ch | Character tab ].
	aStream nextPutAll: 'switch ('.
	expression emitCCodeOn: aStream level: level generator: aCodeGen.
	aStream nextPutAll: ') {'; cr.
	1 to: cases size do: [ :i |
		(firsts at: i) to: (lasts at: i) do: [ :caseIndex |
			aStream nextPutAll: indent, 'case ', caseIndex printString, ':'; cr.
		].
		(cases at: i) emitCCodeOn: aStream level: level + 1 generator: aCodeGen.
		aStream nextPutAll: indent; tab; nextPutAll: 'break;'.
		aStream cr.
	].
	level timesRepeat: [ aStream tab ].
	aStream nextPutAll: '}'.