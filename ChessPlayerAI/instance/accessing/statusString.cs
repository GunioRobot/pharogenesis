statusString
	| av count |
	^String streamContents: 
			[:s | 
			(myMove == #none or: [myMove isNil]) 
				ifFalse: 
					[s
						print: myMove value * 0.01;
						space].
			av := bestVariation.
			count := av first.
			count > 0 
				ifFalse: 
					[av := activeVariation.
					count := av first].
			count > 0 
				ifFalse: 
					[s nextPutAll: '***'.
					av := variations first.
					count := av first.
					count := count min: 3].
			2 to: count + 1
				do: 
					[:index | 
					s nextPutAll: (ChessMove decodeFrom: (av at: index)) moveString.
					s space].
			s nextPut: $[.
			s print: nodesVisited.
			"		s nextPut:$|.
		s print: ttHits.
		s nextPut: $|.
		s print: alphaBetaCuts.
"
			s nextPut: $]]