trailMorph
	"You can't draw trails on me, but try my owner."
	owner == nil ifTrue: [^ nil].
	^ owner trailMorph