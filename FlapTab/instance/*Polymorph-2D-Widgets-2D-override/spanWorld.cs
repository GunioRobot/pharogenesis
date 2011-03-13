spanWorld
	"Fix for making the height/width of a solid tab be the same as the flap."
	
	| container area |
	container := self pasteUpMorph
				ifNil: [self currentWorld].
	area := container clearArea.
	self orientation == #vertical ifTrue: [
		referent vResizing == #rigid
			ifTrue: [self isCurrentlySolid ifTrue: [self height: area height].
					referent height: area height].
		referent hResizing == #rigid
			ifTrue: [referent width: (referent width min: area width - self width)].
		referent top: area top.
		referent bottom: (area bottom min: referent bottom)
	]
	ifFalse: [
		referent hResizing == #rigid
			ifTrue: [self isCurrentlySolid ifTrue: [self width: area width].
					referent width: area width].
		referent vResizing == #rigid
			ifTrue: [referent height: (referent height min: area height - self height)].
		referent left: area left.
		referent right: (area right min: referent right)
	].
