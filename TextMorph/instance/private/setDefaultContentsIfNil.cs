setDefaultContentsIfNil
	"Set the default contents"

	| toUse |
	text ifNil:
		[toUse _ self valueOfProperty: #defaultContents.
		toUse ifNil: [toUse _'abc' asText "allBold"].	"try it plain for a while"
		text _ toUse]