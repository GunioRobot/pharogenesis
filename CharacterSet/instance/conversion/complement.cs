complement
	"return a character set containing precisely the characters the receiver does not"
	| set |
	set _ CharacterSet allCharacters.
	self do: [ :c | set remove: c ].
	^set