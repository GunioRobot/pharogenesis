worldMenu
	^ TheWorldMenu new
		world: self world
		project: Project current
		hand: self world activeHand; yourself