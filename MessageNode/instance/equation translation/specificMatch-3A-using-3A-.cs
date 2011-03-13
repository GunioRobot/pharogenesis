specificMatch: aTree using: matchDict 
	(receiver match: aTree receiver using: matchDict)
		ifFalse: [^false].
	(selector match: aTree selector using: matchDict)
		ifFalse: [^false].
	arguments with: aTree arguments do: [:a1 :a2 |
		(a1 match: a2 using: matchDict)
			ifFalse: [^false]].
	^true