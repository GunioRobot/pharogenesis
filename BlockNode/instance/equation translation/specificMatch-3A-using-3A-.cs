specificMatch: aTree using: matchDict 
	statements with: aTree statements do: [:s1 :s2 |
			(s1 match: s2 using: matchDict) ifFalse: [^false]].
	^true