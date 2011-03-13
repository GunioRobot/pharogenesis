multiSuffixes
	"Unfortunately we can not tell which suffixes use multibyte encoding.
	So we guess that they begin with $m."

	^self sourceFileSuffixes select: [:suff | suff first = $m]