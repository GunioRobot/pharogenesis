addCustomMenuItems: aCustomMenu hand: aHandMorph

	| movies |
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	frameList size > 1 ifTrue: [
		aCustomMenu add: 'repaint' action: #editDrawing.
		aCustomMenu add: 'set rotation center' action: #setRotationCenter.
		aCustomMenu add: 'play once' action: #playOnce.
		aCustomMenu add: 'play loop' action: #playLoop.
		aCustomMenu add: 'stop playing' action: #stopPlaying.
		currentFrameIndex > 1 ifTrue: [
			aCustomMenu add: 'previous frame' action: #previousFrame].
		currentFrameIndex < frameList size ifTrue: [
			aCustomMenu add: 'next frame' action: #nextFrame]].
	aCustomMenu add: 'extract this frame' action: #extractFrame:.
	movies _
		(self world rootMorphsAt: aHandMorph targetOffset)
			select: [:m | (m isKindOf: MovieMorph) or:
						[m isKindOf: SketchMorph]].
	(movies size > 1) ifTrue: [
		aCustomMenu add: 'insert into movie' action: #insertIntoMovie:].
