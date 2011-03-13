asPacked
	"Convert to a longinteger that describes the string"

	^ self inject: 0 into: [ :pack :next | pack _ pack * 256 + next asInteger ].