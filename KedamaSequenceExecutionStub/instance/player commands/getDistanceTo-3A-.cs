getDistanceTo: aPlayer

	| i xy |
	i _ self index.
	xy _ aPlayer getXAndY.
	^ self primGetDistanceToX: xy x toY: xy y fromX: ((turtles arrays at: 2) at: i) fromY: ((turtles arrays at: 3) at: i).
