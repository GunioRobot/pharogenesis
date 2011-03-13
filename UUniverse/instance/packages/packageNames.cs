packageNames
	| names |
	names _ Set new.
	self packages do: [ :p | names add: p name ].
	^names