setDeselectedColor
	"The normal color of the tile, stored with the tile"
	| deselectedColor deselectedBorderColor |

	deselectedColor _ self valueOfProperty: #deselectedColor ifAbsent: [nil].
	deselectedBorderColor _ self valueOfProperty: #deselectedBorderColor ifAbsent: [nil].
	deselectedColor ifNotNil: [
		deselectedColor _ self scaleColorByUserPref: deselectedColor].
	deselectedBorderColor ifNotNil: [
		deselectedBorderColor _ self scaleColorByUserPref: deselectedBorderColor].
	self 
		color: (deselectedColor ifNil: [Color transparent]);
		borderColor: (deselectedBorderColor ifNil: [Color transparent])