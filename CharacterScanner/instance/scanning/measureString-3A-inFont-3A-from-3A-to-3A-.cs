measureString: aString inFont: aFont from: startIndex to: stopIndex
	"WARNING: In order to use this method the receiver has to be set up using #initializeStringMeasurer"
	destX _ destY _ lastIndex _ 0.
	xTable _ aFont xTable.
	self scanCharactersFrom: startIndex to: stopIndex in: aString rightX: 999999 stopConditions: stopConditions kern: 0.
	^destX