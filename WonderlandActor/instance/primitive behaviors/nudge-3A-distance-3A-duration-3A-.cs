nudge: aDirection distance: aDistance duration: aDuration 
	"Nudge the actor the specified object lengths in the specified direction, taking the specified duration and using the Gently animation style."

	|  size newDistance |
	
	(aDuration = rightNow) ifTrue: [
			size _ self getSize.

			((aDirection = #left) or: [ aDirection = #right ])
				ifTrue: [ newDistance _ aDistance * (size at: 1) ]
				ifFalse: [

			((aDirection = #up) or: [ aDirection = #down ])
				ifTrue: [ newDistance _ aDistance * (size at: 2) ]
				ifFalse: [

			((aDirection = #forward) or: [ (aDirection = #back) or: [aDirection = #backward]])
				ifTrue: [ newDistance _ aDistance * (size at: 3) ]
				ifFalse: [ 	myWonderland reportErrorToUser: 'Squeak could not determine which direction to nudge the object because ' , (aDirection asString) , 'is not a valid direction.'.
							^ nil.]]].


			^ self moveRightNow: aDirection distance: newDistance undoable: true ].

	^ self nudge: aDirection distance: aDistance duration: aDuration style: gently.
	

