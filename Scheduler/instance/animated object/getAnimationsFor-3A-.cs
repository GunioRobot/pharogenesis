getAnimationsFor: anObject
	"Return the animations that list anObject as the object they're affecting"

	| animList |
	animList _ OrderedCollection new.

	animationList do: [:anim | ((anim getAnimatedObject) = anObject)
								ifTrue: [ animList addLast: anim ] ].

	^ animList.
