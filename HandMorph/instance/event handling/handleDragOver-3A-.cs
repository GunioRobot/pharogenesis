handleDragOver: evt
	| mList allMouseOvers leftMorphs enteredMorphs |
	owner ifNil: [^ self].  "this hand is not in a world"
	"Start with a list consisting of the topmost unlocked morph in the
	innermost frame (pasteUp), and all of its containers in that frame."
	mList _ self dragOverList: evt.


	"Make a list of all potential drag-overs..."
	allMouseOvers _ mList select:
		[:m | m handlesMouseOverDragging: (evt transformedBy: (m transformFrom: self))].
	leftMorphs _ dragOverMorphs select: [:m | (allMouseOvers includes: m) not].
	enteredMorphs _ allMouseOvers select: [:m | (dragOverMorphs includes: m) not].


	"Notify and remove any morphs that have just been left..."
	leftMorphs do: [:m |
		dragOverMorphs remove: m.
		m mouseLeaveDragging: (evt transformedBy: (m transformFrom: self))].


	"Add any new mouse-overs and send mouseEnter:"
	enteredMorphs do: [:m |
		dragOverMorphs add: m.
		mouseOverMorphs remove: m ifAbsent: [].  "Cant be in two places at once"
		m mouseEnterDragging: (evt transformedBy: (m transformFrom: self))].