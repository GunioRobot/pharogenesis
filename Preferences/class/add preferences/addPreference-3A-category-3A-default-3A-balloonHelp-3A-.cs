addPreference: prefSymbol category: categorySymbol default: defaultFlag
balloonHelp: helpString 
	self class compileProgrammatically: (#initialValuesAddition ,
categorySymbol , prefSymbol) asString , '
	^ #((' , prefSymbol asSymbol, ' ' , defaultFlag printString , ' (' ,
categorySymbol asSymbol, ' ) ) )' classified: 'initial values'.

	self class compileProgrammatically: (#helpMsgsAddition , categorySymbol
, prefSymbol) asString , '
	^ #((' , prefSymbol, ' ', helpString printString, ' ) )' classified:
'help'.

	self absorbAdditions
