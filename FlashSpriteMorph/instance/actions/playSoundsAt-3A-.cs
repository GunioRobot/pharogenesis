playSoundsAt: frame
	(sounds at: frame ifAbsent:[#()]) 
		do: [:sound | sound ifNotNil:[self playFlashSound: sound]].