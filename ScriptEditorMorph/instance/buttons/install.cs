install
	"Keep me for editing"

	self removeSpaces.
	scriptName ifNotNil:
		[playerScripted acceptScript: self topEditor for:  scriptName asSymbol]