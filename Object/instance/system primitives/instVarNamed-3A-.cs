instVarNamed: aString
	"Return the value of the instance variabvle in me with that name.  Slow and unclean, but very useful.  "

	^ self instVarAt: ((self class allInstVarNames) indexOf: aString)
