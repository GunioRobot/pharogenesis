attributeArrayForColor: aColorOrNil emphasis: anEmphasisSymbolOrArrayorNil font: aTextStyleOrFontOrNil
	"Answer a new Array containing any non nil TextAttributes specified"
	| answer emphArray |

	answer := Array new.
	aColorOrNil ifNotNil: [answer := answer, {TextColor color: aColorOrNil}].
	anEmphasisSymbolOrArrayorNil ifNotNil: [
		emphArray := anEmphasisSymbolOrArrayorNil isSymbol 
			ifTrue: [{anEmphasisSymbolOrArrayorNil}] 
			ifFalse: [anEmphasisSymbolOrArrayorNil].
		emphArray do: [:each |
			each ~= #normal
				ifTrue:[
					answer := answer, {TextEmphasis perform: each}]]].
	aTextStyleOrFontOrNil ifNotNil: [
		answer := answer, {TextFontReference toFont: aTextStyleOrFontOrNil}].
	^answer