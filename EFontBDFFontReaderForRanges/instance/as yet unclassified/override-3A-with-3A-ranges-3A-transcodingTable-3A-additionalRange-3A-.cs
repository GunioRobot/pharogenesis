override: chars with: otherFileName ranges: pairArray transcodingTable: table additionalRange: additionalRange

	| other rangeStream currentRange newChars code form u newArray j |
	other _ BDFFontReader readOnlyFileNamed: otherFileName.

	rangeStream _ ReadStream on: pairArray.
	currentRange _ rangeStream next.

	newChars _ PluggableSet new.
	newChars hashBlock: [:elem | (elem at: 2) hash].
	newChars equalBlock: [:a :b | (a at: 2) = (b at: 2)].

	other readChars do: [:array | 
		code _ array at: 2.
		code hex printString displayAt: 0@0.
		code > currentRange last ifTrue: [
			[rangeStream atEnd not and: [currentRange _ rangeStream next. currentRange last < code]] whileTrue.
			rangeStream atEnd ifTrue: [
				newChars addAll: chars.
				^ newChars.
			].
		].
		(code between: currentRange first and: currentRange last) ifTrue: [
			form _ array at: 1.
			form ifNotNil: [
				j _ array at: 2.
				u _ table at: (((j // 256) - 33 * 94 + ((j \\ 256) - 33)) + 1).
				u ~= -1 ifTrue: [
					array at: 2 put: u.
					newChars add: array.
					additionalRange do: [:e |
						e first = (array at: 2) ifTrue: [
							newArray _ array clone.
							newArray at: 2 put: e second.
							newChars add: newArray
						].
					]
				].
			].
		].
	].

	self error: 'should not reach here'.
