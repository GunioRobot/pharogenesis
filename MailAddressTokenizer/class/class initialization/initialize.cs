initialize
	"Initalize class variables using   MailAddressTokenizer initialize"

	| atomChars |

	CSParens _ CharacterSet empty.
	CSParens addAll: '()'.

	CSSpecials _ CharacterSet empty.
	CSSpecials addAll: '()<>@,;:\".[]'.

	CSNonSeparators _ CharacterSet separators complement.


	"(from RFC 2822)"
	atomChars := CharacterSet empty.
	atomChars addAll: ($A to: $Z).
	atomChars addAll: ($a to: $z).
	atomChars addAll: ($0 to: $9).
	atomChars addAll: '!#$%^''*+-/=?^_`{|}~'.

	CSNonAtom :=  atomChars complement.