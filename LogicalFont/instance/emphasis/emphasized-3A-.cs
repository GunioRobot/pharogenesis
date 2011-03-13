emphasized: code
	| validCode newWeight newSlant answer  validCodeMask |

	"we only handle bold and italic here since underline/strikeout are drawn separately"
	validCodeMask := self class squeakWeightBold bitOr: self class squeakSlantItalic.
	validCode := code bitAnd: validCodeMask. 
	validCode = 0 ifTrue:[^self].
	(validCode anyMask: self class squeakWeightBold) 
		ifTrue:[newWeight := self class weightBold max: weightValue] 
		ifFalse:[newWeight := weightValue].
	((validCode anyMask:  self class squeakSlantItalic) and:[self isItalicOrOblique not]) 
		ifTrue:[newSlant := self class slantItalic]
		ifFalse:[newSlant := slantValue].
	(weightValue = newWeight and:[slantValue = newSlant]) ifTrue:[^self].
	(weightValue ~= newWeight and:[slantValue ~= newSlant])
		ifTrue:[
			boldItalicDerivative ifNotNil:[^boldItalicDerivative]]
		ifFalse:[
			(weightValue ~= newWeight)
				ifTrue:[boldDerivative ifNotNil:[^boldDerivative]].
			(slantValue ~= newSlant)
				ifTrue:[italicDerivative ifNotNil:[^italicDerivative]]].		
	answer := self class 
		familyName: familyName 
		fallbackFamilyNames: fallbackFamilyNames 
		pointSize: pointSize 
		stretchValue: stretchValue 
		weightValue: newWeight 
		slantValue: newSlant.
	(weightValue ~= newWeight and:[slantValue ~= newSlant])
		ifTrue:[^boldItalicDerivative := answer].
	(weightValue ~= newWeight)
		ifTrue:[^boldDerivative := answer].
	(slantValue ~= newSlant)
		ifTrue:[^italicDerivative := answer].	
	^answer
