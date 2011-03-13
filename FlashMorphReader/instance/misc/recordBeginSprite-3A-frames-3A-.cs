recordBeginSprite: id frames: frameCount
	| sprite |
	sprite := FlashSpriteMorph new.
	sprite maxFrames: frameCount.
	sprite stepTime: stepTime.
	spriteOwners at: sprite put: (
		Array with: player 
			with: frame
			with: activeMorphs
			with: passiveMorphs).
	player := sprite.
	frame := 1.
	activeMorphs := Dictionary new: 100.
	passiveMorphs := Dictionary new: 100.
