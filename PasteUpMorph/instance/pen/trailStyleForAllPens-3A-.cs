trailStyleForAllPens: aTrailStyle
	"Ascribe the given trail style to all pens of objects within me"

	submorphs do: [:m | m assuredPlayer setTrailStyle: aTrailStyle]
