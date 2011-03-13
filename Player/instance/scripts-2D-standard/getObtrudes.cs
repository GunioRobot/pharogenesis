getObtrudes
	"Answer whether the receiver's costume obtrudes beyond the bounds of its container"

	| aCostume |
	(aCostume _ self costume) ifNil: [^ false].
	^ aCostume obtrudesBeyondContainer
