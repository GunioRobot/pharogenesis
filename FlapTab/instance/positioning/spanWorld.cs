spanWorld
	| container |

	container _ self pasteUpMorph ifNil: [self currentWorld].
	(self orientation == #vertical) ifTrue: [
		referent vResizing == #rigid 
			ifTrue:[referent height: container height].
		referent hResizing == #rigid 
			ifTrue:[referent width: (referent width min: container width - self width)].
		referent top: container top.
	] ifFalse: [
		referent hResizing == #rigid
			ifTrue:[referent width: container width].
		referent vResizing == #rigid
			ifTrue:[referent height: (referent height min: container height - self height)].
		referent left: container left.
	] 