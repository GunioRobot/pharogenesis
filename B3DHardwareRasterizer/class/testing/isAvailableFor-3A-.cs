isAvailableFor: aForm
	"Return true if this part of the engine is available for the given output medium"
	aForm ifNil:[^false].
	(aForm isDisplayScreen and:[aForm isB3DDisplayScreen]) ifFalse:[^false].
	^self isAvailable