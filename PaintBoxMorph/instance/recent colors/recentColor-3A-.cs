recentColor: aColor
	"Remember the color as one of our recent colors"
	(recentColors anySatisfy:[:any| any color = aColor]) ifTrue:[^self]. "already remembered"
	recentColors size to: 2 by: -1 do:[:i|
		(recentColors at: i) color: (recentColors at: i-1) color.
	].
	(recentColors at: 1) color: aColor.