pushUpMethods

	(String selectors reject: [:each | #(compare:with:collated:  < >= compare: <= byteSize byteAt:put: = at:put:  replaceFrom:to:with:startingAt:   >  byteAt:  sameAs:  caseInsensitiveLessOrEqual: at: caseSensitiveLessOrEqual:) includes: each]) do: [:sel |
		AbstractString copy: sel from: String.
		String removeSelector: sel.
	].

	((String class selectors reject: [:each | #(findFirstInString:inSet:startingAt: ccgDeclareCForVar: translate:from:to:table: ccg:prolog:expr:index: stringHash:initialHash: indexOfAscii:inString:startingAt: fromByteArray: correspondingSymbolClass) includes: each]) reject: [:each | (String class organization categoryOfElement: each) = (String class organization categoryOfElement: #conv)]) do: [:sel |
		AbstractString class copy: sel from: String class.
		String class removeSelector: sel.
	].

	"#(asMultiString convertToSystemString  convertFromWithConverter: includesUnifiedCharacter convertToWithConverter: convertFromSystemString asOctetString convertFromCompoundText isOctetString asTranslatedWording)"