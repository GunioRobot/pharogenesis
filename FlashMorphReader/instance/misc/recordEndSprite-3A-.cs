recordEndSprite: id
	| shape sprite |
	sprite _ player.
	player _ (spriteOwners at: sprite) at: 1.
	frame _ (spriteOwners at: sprite) at: 2.
	activeMorphs _ (spriteOwners at: sprite) at: 3.
	passiveMorphs _ (spriteOwners at: sprite) at: 4.
	spriteOwners removeKey: sprite.
	sprite loadInitialFrame.
	shape _ FlashCharacterMorph withAll: (Array with: sprite).
	shape id: id.
	shape isSpriteHolder: true.
	shape stepTime: stepTime.
	shapes at: id put: shape.
	shape lockChildren.
