unusedScriptName
	"answer a name of the form 'sssScriptN', where N is one higher than the highest-numbered similarly-named script"
	| highestThus aPair |
	highestThus _ 0.
	self class tileScriptNames do:
		[:aName |
			aPair _ aName stemAndNumericSuffix.
			aPair first = 'xxxScript' ifTrue: [highestThus _ highestThus max: aPair last]].
	^ ('xxxScript', (highestThus + 1) printString) asSymbol