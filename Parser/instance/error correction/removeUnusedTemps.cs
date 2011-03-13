removeUnusedTemps 
	| str end start | 
	str _ requestor text string.
	((tempsMark between: 1 and: str size)
		and: [(str at: tempsMark) = $|]) ifFalse: [^ self].
	encoder unusedTempNames do:
		[:temp |
		((PopUpMenu labels: 'yes\no' withCRs) startUpWithCaption:
			((temp , ' appears to be
unused in this method.
OK to remove it?') asText makeBoldFrom: 1 to: temp size))
			= 1
		ifTrue:
		[(encoder encodeVariable: temp) isUndefTemp
			ifTrue:
			[end _ tempsMark.
			["Beginning at right temp marker..."
			start _ end - temp size + 1.
			end < temp size or: [temp = (str copyFrom: start to: end)
					and: [(str at: start-1) isSeparator & (str at: end+1) isSeparator]]]
			whileFalse:
				["Search left for the unused temp"
				end _ requestor nextTokenFrom: end direction: -1].
			end < temp size ifFalse:
				[(str at: start-1) = $  ifTrue: [start _ start-1].
				requestor correctFrom: start to: end with: ''.
				str _ str copyReplaceFrom: start to: end with: ''. 
				tempsMark _ tempsMark - (end-start+1)]]
			ifFalse:
			[PopUpMenu notify:
'You''ll first have to remove the
statement where it''s stored into']]]