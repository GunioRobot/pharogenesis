updateLiteralLabel
	"Update the wording emblazoned on the tile, if needed.  Copied down, for jimmying, unfortunately"

	| myLabel |
	(myLabel _ self labelMorph) ifNil: [^ self].
	myLabel useSymbolFormat.
	myLabel acceptValue: literal asString.
	self changed.