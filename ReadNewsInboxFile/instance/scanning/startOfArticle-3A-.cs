startOfArticle: aString
	"Answer true if the given string is the start of a new news article. That is, does it start with the string 'Article ' and end with a period?"

	^((aString size >= 8) and:
	   [((aString copyFrom: 1 to: 8) = 'Article ') & (aString last = $.)])