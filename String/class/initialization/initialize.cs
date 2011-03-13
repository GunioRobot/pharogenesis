initialize   "self initialize"

	| order |
	AsciiOrder _ (0 to: 255) as: ByteArray.

	CaseInsensitiveOrder _ AsciiOrder copy.
	($a to: $z) do:
		[:c | CaseInsensitiveOrder at: c asciiValue + 1
				put: (CaseInsensitiveOrder at: c asUppercase asciiValue +1)].

	"Case-sensitive compare sorts space, digits, letters, all the rest..."
	CaseSensitiveOrder _ ByteArray new: 256 withAll: 255.
	order _ -1.
	' 0123456789' do:  "0..10"
		[:c | CaseSensitiveOrder at: c asciiValue + 1 put: (order _ order+1)].
	($a to: $z) do:     "11-64"
		[:c | CaseSensitiveOrder at: c asUppercase asciiValue + 1 put: (order _ order+1).
		CaseSensitiveOrder at: c asciiValue + 1 put: (order _ order+1)].
	1 to: CaseSensitiveOrder size do:
		[:i | (CaseSensitiveOrder at: i) = 255 ifTrue:
			[CaseSensitiveOrder at: i put: (order _ order+1)]].
	order = 255 ifFalse: [self error: 'order problem'].

	"a table for translating to lower case"
	LowercasingTable _ String withAll: (Character allByteCharacters collect: [:c | c asLowercase]).

	"a table for translating to upper case"
	UppercasingTable _ String withAll: (Character allByteCharacters collect: [:c | c asUppercase]).

	"a table for testing tokenish (for fast numArgs)"
	Tokenish _ String withAll: (Character allByteCharacters collect:
									[:c | c tokenish ifTrue: [c] ifFalse: [$~]]).

	"CR and LF--characters that terminate a line"
	CSLineEnders _ CharacterSet empty.
	CSLineEnders add: Character cr.
	CSLineEnders add: Character lf.

 	"separators and non-separators"
	CSSeparators _ CharacterSet separators.
	CSNonSeparators _ CSSeparators complement.