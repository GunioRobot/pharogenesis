moveCursor: directionBlock forward: forward specialBlock: specialBlock
	"Private - Move cursor.
	directionBlock is a one argument Block that computes the new Position from a given one.
	specialBlock is a one argumentBlock that computes the new position from a given one under the alternate semantics.
	Note that directionBlock always is evaluated first."
	| shift indices newPosition |
	shift _ sensor leftShiftDown.
	indices _ self setIndices: shift forward: forward.
	newPosition _ directionBlock value: (indices at: #moving).
	(sensor commandKeyPressed or:[sensor controlKeyPressed])
		ifTrue: [newPosition _ specialBlock value: newPosition].
	sensor keyboard.
	shift
		ifTrue: [self selectMark: (indices at: #fixed) point: newPosition - 1]
		ifFalse: [self selectAt: newPosition]