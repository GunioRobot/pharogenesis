changeListDirection: aSymbol
	| listDir wrapDir |
	self listDirection: aSymbol.
	(self wrapDirection == #none) ifTrue:[^self].
	"otherwise automatically keep a valid table layout"
	listDir _ self listDirection.
	wrapDir _ self wrapDirection.
	(listDir == #leftToRight or:[listDir == #rightToLeft]) ifTrue:[
		wrapDir == #leftToRight ifTrue:[^self wrapDirection: #topToBottom].
		wrapDir == #rightToLeft ifTrue:[^self wrapDirection: #bottomToTop].
	] ifFalse:[
		wrapDir == #topToBottom ifTrue:[^self wrapDirection: #leftToRight].
		wrapDir == #bottomToTop ifTrue:[^self wrapDirection: #rightToLeft].
	].
