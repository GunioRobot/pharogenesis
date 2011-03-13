removeUnusedTemps
	"Scan for unused temp names, and prompt the user about the prospect of removing each one found"

	| str end start madeChanges | 
	madeChanges _ false.
	str _ requestor text string.
	((tempsMark between: 1 and: str size)
		and: [(str at: tempsMark) = $|]) ifFalse: [^ self].
	encoder unusedTempNames do:
		[:temp |
		(encoder encodeVariable: temp) isUndefTemp
			ifTrue:
			[(UIManager default 
				confirm: (temp , ' appears to be\unused in this method.\OK to remove it?') withCRs)
				ifTrue: [end _ tempsMark.
						["Beginning at right temp marker..."
						start _ end - temp size + 1.
						end < temp size or: [temp = (str copyFrom: start to: end)
							and: [(str at: start-1) isAlphaNumeric not & (str at: end+1) isAlphaNumeric not]]]
						whileFalse: ["Search left for the unused temp"
									end _ requestor nextTokenFrom: end direction: -1].
						end < temp size ifFalse:
						[(str at: start-1) = $  ifTrue: [start _ start-1].
						requestor correctFrom: start to: end with: ''.
						str _ str copyReplaceFrom: start to: end with: ''. 
						madeChanges _ true.
						tempsMark _ tempsMark - (end-start+1)]]]].
	madeChanges ifTrue: [ParserRemovedUnusedTemps signal]