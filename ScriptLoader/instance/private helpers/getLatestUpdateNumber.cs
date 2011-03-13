getLatestUpdateNumber

	| upfroms |
	upfroms := ScriptLoader selectors select: [:each | 'updateFrom*' match: each ].
	upfroms := upfroms collect: [:each | (each asString last: 4) asNumber].
	^ upfroms asSortedCollection last