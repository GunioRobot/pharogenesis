allCharacters
	"return a set containing all characters"

	| set |
	set _ self empty.
	0 to: 255 do: [ :ascii | set add: (Character value: ascii) ].
	^set