placeRightNow: aLocation object: aTarget undoable: isUndoable
	"Instantaneously move the object to the specified place."

	 | selfPos selfBBox selfLBB selfRUF objBBox objLBB objRUF pos |

	selfBBox _ self getBoundingBox: aTarget.
	selfLBB _ selfBBox origin.
	selfRUF _ selfBBox corner.

	objBBox _ aTarget getBoundingBox.
	objLBB _ objBBox origin.
	objRUF _ objBBox corner.

	selfPos _ self getPosition: aTarget.

	((aLocation = onTopOf) or: [ aLocation = above])
	ifTrue: [
				pos _ { 0. (objRUF y) + ((selfPos at: 2) - (selfLBB y)). 0}
			]
 	ifFalse: [

	((aLocation = onBottomOf) or: [ (aLocation = beneath) or: [ aLocation = below ] ])
	ifTrue: [
				pos _ { 0. (objLBB y) - ((selfRUF y) - (selfPos at: 2)). 0}
			]
	ifFalse: [

	(aLocation = toLeftOf)
	ifTrue: [
				pos _ { (objLBB x) - ((selfRUF x) - (selfPos at: 1)). 0. 0 }
			]
	ifFalse: [

	(aLocation = toRightOf)
	ifTrue: [
				pos _ { (objRUF x) + ((selfPos at: 1) - (selfLBB x)). 0. 0 }
			]
	ifFalse: [

	(aLocation = inFrontOf)
	ifTrue: [
				pos _ { 0. 0. (objRUF z) + ((selfPos at: 3) - (selfLBB z)) }
			]
	ifFalse: [

	((aLocation = inBackOf) or: [ aLocation = behind])
	ifTrue: [
				pos _ { 0. 0. (objLBB z) - ((selfRUF z) - (selfPos at:3)) }
			]
	ifFalse: [

	(aLocation = onCeilingOf)
	ifTrue: [
				pos _ { 0. (objRUF y) - ((selfRUF y) - (selfPos at:2)). 0}
			]
	ifFalse: [

	(aLocation = onFloorOf)
	ifTrue: [
				pos _ { 0. (objLBB y) + ((selfPos at: 2) - (selfLBB y)). 0}
			]
	ifFalse: [ self error: 'Unrecognized target surface' ]]]]]]]].


	self moveToRightNow: pos asSeenBy: aTarget undoable: isUndoable.