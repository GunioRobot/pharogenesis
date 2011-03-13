noticeMouseOver: aMorph event: anEvent
	"Remember that the mouse is currently over some morph"
	
	leftMorphs isNil ifFalse: [
		(leftMorphs includes: aMorph) 
			ifTrue:[leftMorphs remove: aMorph]
			ifFalse:[enteredMorphs nextPut: aMorph].
		overMorphs nextPut: aMorph.]

	