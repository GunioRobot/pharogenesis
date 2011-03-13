ownerSprite
	"Return the sprite owning the receiver.
	The owning sprite is responsible for executing
	the actions associated with the button."
	^ self orOwnerSuchThat: [:sprite | sprite isFlashMorph and: [sprite isFlashSprite]]