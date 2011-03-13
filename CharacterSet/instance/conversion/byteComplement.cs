byteComplement
	"return a character set containing precisely the single byte characters the receiver does not"
	
	| set |
	set _ CharacterSet allCharacters.
	self do: [ :c | set remove: c ].
	^set