ownerSprite
	"Return the sprite owning the receiver.
	The owning sprite is responsible for executing
	the actions associated with the button."
	| sprite |
	sprite _ self.
	[sprite isNil] whileFalse:[
		(sprite isFlashMorph and:[sprite isFlashSprite]) ifTrue:[^sprite].
		sprite _ sprite owner].
	^nil