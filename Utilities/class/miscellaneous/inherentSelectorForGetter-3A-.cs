inherentSelectorForGetter: aGetterSelector
	"Given a selector of the form #getAbc, return the inherent slotname selector that corresponds, which is to say, getterSelector with the leading 'get' removed and with the next character forced to lower case; this is the inverse of #getterSelectorFor:"

	"Utilities inherentSelectorForGetter: #getWidth"
	((aGetterSelector size < 4) or: [(aGetterSelector beginsWith: 'get') not])
			ifTrue: [ ^ aGetterSelector].
	^ ((aGetterSelector at: 4) asLowercase asString, (aGetterSelector copyFrom: 5 to: aGetterSelector size)) asSymbol