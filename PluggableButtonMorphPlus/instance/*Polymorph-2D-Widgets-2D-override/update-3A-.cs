update: aParameter
	"Update the receiver with any changes in the model."
	
	aParameter ifNil: [^self].
	super update: aParameter.
	aParameter == getEnabledSelector ifTrue: [
		^self enabled: (model perform: getEnabledSelector)]