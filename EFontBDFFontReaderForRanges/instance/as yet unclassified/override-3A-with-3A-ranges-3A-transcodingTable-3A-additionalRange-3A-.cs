override: chars with: otherFileName ranges: pairArray transcodingTable: table additionalRange: additionalRange 
	| other rangeStream currentRange newChars code form u newArray j |
	other := BDFFontReader readOnlyFileNamed: otherFileName.
	rangeStream := pairArray readStream.
	currentRange := rangeStream next.
	newChars := PluggableSet new.
	newChars hashBlock: [ :elem | (elem at: 2) hash ].
	newChars equalBlock: [ :a :b | (a at: 2) = (b at: 2) ].
	other readChars do: 
		[ :array | 
		code := array at: 2.
		"code printStringHex printString displayAt: 0@0."
		code > currentRange last ifTrue: 
			[ 
			[ rangeStream atEnd not and: 
				[ currentRange := rangeStream next.
				currentRange last < code ] ] whileTrue.
			rangeStream atEnd ifTrue: 
				[ newChars addAll: chars.
				^ newChars ] ].
		(code 
			between: currentRange first
			and: currentRange last) ifTrue: 
			[ form := array at: 1.
			form ifNotNil: 
				[ j := array at: 2.
				u := table at: (j // 256 - 33) * 94 + (j \\ 256 - 33) + 1.
				u ~= -1 ifTrue: 
					[ array 
						at: 2
						put: u.
					newChars add: array.
					additionalRange do: 
						[ :e | 
						e first = (array at: 2) ifTrue: 
							[ newArray := array clone.
							newArray 
								at: 2
								put: e second.
							newChars add: newArray ] ] ] ] ] ].
	self error: 'should not reach here'