addCustomMenuItems: aCustomMenu hand: aHandMorph

	| movies subMenu |
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	subMenu _ MenuMorph new defaultTarget: self.
	frameList size > 1 ifTrue: [
		subMenu add: 'repaint' action: #editDrawing.
		subMenu add: 'set rotation center' action: #setRotationCenter.
		subMenu add: 'play once' action: #playOnce.
		subMenu add: 'play loop' action: #playLoop.
		subMenu add: 'stop playing' action: #stopPlaying.
		currentFrameIndex > 1 ifTrue: [
			subMenu add: 'previous frame' action: #previousFrame].
		currentFrameIndex < frameList size ifTrue: [
			subMenu add: 'next frame' action: #nextFrame]].
	subMenu add: 'extract this frame' action: #extractFrame:.
	movies _
		(self world rootMorphsAt: aHandMorph targetOffset)
			select: [:m | (m isKindOf: MovieMorph) or:
						[m isKindOf: SketchMorph]].
	(movies size > 1) ifTrue:
		[subMenu add: 'insert into movie' action: #insertIntoMovie:].
	aCustomMenu add: 'movie...' subMenu: subMenu
