specificMatch: aTree using: matchDict 
	(receiver match: aTree receiver using: matchDict)
		ifFalse: [^false].
	messages with: aTree messages do: [:m1 :m2 |
			(m1 match: m2 using: matchDict) ifFalse: [^false]].
	^true