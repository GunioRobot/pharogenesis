setupNest: aPatch
	"Create a nest of radius 5 centered at 50@50."

	| distanceToNest |
	distanceToNest := aPatch distanceTo: 50@50.
	distanceToNest <= 4
		ifTrue: [
			aPatch set: 'isNest' to: 1.
			aPatch color: Color brown lighter]
		ifFalse: [aPatch set: 'isNest' to: 0].

	"create a 'hill' of nest scent centered on the nest"
	distanceToNest > 0 ifTrue: [
		aPatch set: 'nestScent' to: 10000.0 // distanceToNest].

