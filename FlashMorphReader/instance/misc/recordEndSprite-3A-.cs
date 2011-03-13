recordEndSprite: id
	| shape sprite |
	sprite := player.
	player := (spriteOwners at: sprite) at: 1.
	frame := (spriteOwners at: sprite) at: 2.
	activeMorphs := (spriteOwners at: sprite) at: 3.
	passiveMorphs := (spriteOwners at: sprite) at: 4.
	spriteOwners removeKey: sprite.
	sprite loadInitialFrame.
	shape := FlashCharacterMorph withAll: (Array with: sprite).
	shape id: id.
	shape isSpriteHolder: true.
	shape stepTime: stepTime.
	shapes at: id put: shape.
	shape lockChildren.
