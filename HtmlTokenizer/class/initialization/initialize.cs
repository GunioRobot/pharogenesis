initialize
	"HtmlTokenizer initialize"

	CSAttributeEnders _ CharacterSet empty.
	CSAttributeEnders addAll: Character separators.
	CSAttributeEnders add: $>.
	
	CSNameEnders _ CharacterSet empty.
	CSNameEnders addAll: '=>'.
	CSNameEnders addAll: Character separators.

	CSNonSeparators _ CharacterSet separators complement.