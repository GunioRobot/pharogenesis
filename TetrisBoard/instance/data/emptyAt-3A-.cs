emptyAt: aPoint

	| cellOrigin |
	(aPoint x between: 1 and: self numColumns) ifFalse: [^ false].
	(aPoint y < 1) ifTrue: [^ true].	"handle early phases"
	(aPoint y <= self numRows) ifFalse: [^ false].
	cellOrigin _ self originForCell: aPoint.
	^(self submorphsSatisfying: [ :each | each topLeft = cellOrigin]) isEmpty

