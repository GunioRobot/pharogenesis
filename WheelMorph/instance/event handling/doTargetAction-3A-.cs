doTargetAction: cursorPoint
	| new delta |
	self isHorizontal
		ifTrue: [new := cursorPoint x]
		ifFalse: [new := cursorPoint y].
	delta := new - old.
	delta isZero ifTrue: [^self].
	self addAngle: delta.
	(target ~~ nil and: [actionSelector ~~ nil]) ifTrue: [
		Cursor normal showWhile: [
			target perform: actionSelector withArguments: (Array with: (delta * self factor))]].
	old := new.
