recordBeginSprite: id frames: frameCount
	| sprite |
	sprite _ FlashSpriteMorph new.
	sprite maxFrames: frameCount.
	sprite stepTime: stepTime.
	spriteOwners at: sprite put: (
		Array with: player 
			with: frame
			with: activeMorphs
			with: passiveMorphs).
	player _ sprite.
	frame _ 1.
	activeMorphs _ Dictionary new: 100.
	passiveMorphs _ Dictionary new: 100.
