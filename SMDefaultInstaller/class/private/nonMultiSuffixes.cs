nonMultiSuffixes
	"Unfortunately we can not tell which suffixes use multibyte encoding.
	So we guess that they begin with $m."

	^self sourceFileSuffixes reject: [:suff | suff first = $m]