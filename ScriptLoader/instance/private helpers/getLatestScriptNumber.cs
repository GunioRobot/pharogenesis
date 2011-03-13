getLatestScriptNumber

	| upfroms |
	upfroms := ScriptLoader selectors select: [:each | 'script*' match: each ].
	upfroms := upfroms collect: [:each | (each asString allButFirst: 6)].
	upfroms := upfroms reject: [:each | '*Log*' match: each ].
	upfroms := upfroms reject: [:each | '*XXX*' match: each ].
	upfroms := upfroms collect: [:each | each asNumber].
	^ upfroms asSortedCollection last
	