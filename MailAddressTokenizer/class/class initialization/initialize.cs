initialize
	"Initalize class variables using   MailAddressTokenizer initialize"

	| skipCharacters |

	CSParens _ CharacterSet empty.
	CSParens addAll: '()'.

	CSSpecials _ CharacterSet empty.
	CSSpecials addAll: '()<>@,;:\".[]'.

	skipCharacters _ CharacterSet separators.
	0 to: 31 do: [ :c |
		skipCharacters add: (Character value: c) ].
	skipCharacters add: (Character value: 127).

	CSNonSeparators _ skipCharacters complement.

	CSNonAtom _ skipCharacters addAll: CSSpecials.

