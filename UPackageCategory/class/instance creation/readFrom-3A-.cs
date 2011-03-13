readFrom: aStream
	"[UPackageCategory readFromString: 'Core/Umbrella Packages']"
	| comps nextComp |
	comps := OrderedCollection new.
	[aStream atEnd] whileFalse: [
		nextComp := (aStream upTo: $/) withBlanksTrimmed.
		nextComp isEmpty ifFalse: [
			comps add: nextComp ] ].
	
	^self withComponents: comps