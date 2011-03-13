x: aNumber
	"Set my horizontal position relative to the left edge of the playfield or the world."

	|  offset  aPlayfield newX |

	aPlayfield _ self referencePlayfield.
	offset _ self left - self referencePosition x.
	aPlayfield == nil
		ifTrue: [newX _ aNumber + offset]
		ifFalse: [newX _ aPlayfield left + aNumber + offset].
	self position: newX@bounds top.

