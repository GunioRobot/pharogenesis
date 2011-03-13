setWorldColor
| world |
world _ self world.
	world
		changeColorTarget: world
		selector: #color:
		originalColor: world color
		hand: world activeHand