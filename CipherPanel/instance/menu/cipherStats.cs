cipherStats

	| letterCounts digraphs d digraphCounts |
	letterCounts _ (quote copyWithout: Character space) asBag sortedCounts.
	digraphs _ Bag new.
	quote withIndexDo:
		[:c :i |
		i < quote size ifTrue:
			[d _ quote at: i+1.
			(c ~= Character space and: [d ~= Character space]) ifTrue:
				[digraphs add: (String with: c with: d)]]].
	digraphCounts _ digraphs sortedCounts.
	^ String streamContents:
		[:strm |
		1 to: 10 do:
			[:i |
			strm cr; tab; nextPut: (letterCounts at: i) value.
			strm tab; print: (letterCounts at: i) key.
			(digraphCounts at: i) key > 1 ifTrue:
				[strm tab; tab; tab; nextPutAll: (digraphCounts at: i) value.
				strm tab; print: (digraphCounts at: i) key]]]