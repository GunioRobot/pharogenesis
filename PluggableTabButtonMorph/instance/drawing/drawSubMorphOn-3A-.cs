drawSubMorphOn: aCanvas
	| morphBounds |
	morphBounds _ self bounds insetBy: (self cornerRadius + 3) @ (self topInactiveGap // 2 + 2).
	morphBounds _ morphBounds translateBy: 0@(self topInactiveGap // 2 + 1).
	self active ifTrue: [
		morphBounds _ morphBounds translateBy: 0@((self topInactiveGap // 2 + 1) negated)].
	self subMorph bounds height < (morphBounds height)
		ifTrue: [
			morphBounds _ morphBounds
				insetBy: 0@((morphBounds height - self subMorph bounds height) // 2)].
	self subMorph bounds width < (morphBounds width)
		ifTrue: [
			morphBounds _ morphBounds
				insetBy: ((morphBounds width - self subMorph bounds width) // 2)@0].

	self subMorph bounds: morphBounds.			
	aCanvas drawMorph: self subMorph