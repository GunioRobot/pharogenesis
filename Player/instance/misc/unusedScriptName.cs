unusedScriptName
	"answer a name of the form 'scriptN', where N is one higher than the highest-numbered similarly-named script"

	| highestThus aPair |
	highestThus _ 0.
	self class tileScriptNames do:
		[:aName |
			aPair _ (aName copyWithout: $:) stemAndNumericSuffix.
			aPair first = 'script' translated ifTrue: [highestThus _ highestThus max: aPair last]].
	^ ('script' translated, (highestThus + 1) printString) asSymbol