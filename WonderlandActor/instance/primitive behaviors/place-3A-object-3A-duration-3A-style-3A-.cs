place: aLocation object: aTarget duration: aDuration style: aStyle
	"Moves this object to one of several pre-determined locations relative to the target object."

	 | anim selfPos selfBBox selfLBB selfRUF objBBox objLBB objRUF pos |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyLocation: aLocation ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to place ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyActor: aTarget ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to place ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for placing ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to place ' , myName , ' because ', msg.
			^ nil ].

	"The parameters check out, so build the animation"
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


	anim _	self moveTo: pos duration: aDuration asSeenBy: aTarget style: aStyle.

	^ anim.
