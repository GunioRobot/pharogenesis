selectedTranslation: anInteger 
	"change the receiver's selectedTranslation"
	selectedTranslation := anInteger.
	""
	self changed: #selectedTranslation.
	self changed: #translation