hasAtLeastTheSamePropertiesAs: aMethodProperties
	"Answer if the recever has at least the same properties as the argument.
	 N.B. The receiver may have additional properties and still answer true."
	aMethodProperties keysAndValuesDo:
		[:k :v|
		properties ifNil: [^false].
		^(properties at: k ifAbsent: [^false]) = v].
	^true