copyExtension
	"Copy my extensions dictionary"
	| ext |
	extension ifNil:[^self].
	ext _ extension copy.
	ext removeOtherProperties.
	extension otherProperties ifNotNil:[
		extension otherProperties associationsDo:[:assoc|
			ext setProperty: assoc key toValue: assoc value copy.
		].
	].
	extension _ ext.