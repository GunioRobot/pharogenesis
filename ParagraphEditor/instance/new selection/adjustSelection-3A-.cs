adjustSelection: directionBlock
	"Helper function for Cursor movement. Always moves point thus allowing selections to shrink. "
	"See also expandSelection:"
	"Accepts a one argument Block that computes the new postion given an old one."
	| newPosition |
	newPosition _ directionBlock value: self pointIndex.
	self selectMark: self markIndex point: newPosition.
	^true.