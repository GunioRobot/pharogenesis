instVarNamed: aString put: aValue
	"Store into the value of the instance variable in me of that name.  Slow and unclean, but very useful. "

	^ self instVarAt: (self class allInstVarNames indexOf: aString asString) put: aValue
