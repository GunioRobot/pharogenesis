setWorldColor
| world |
world := self world.
	world
		changeColorTarget: world
		selector: #color:
		originalColor: world color
		hand: world activeHand