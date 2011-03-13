allRoutesDo: aBlock currentRoute: currentRoute level: level
	"Recursively iterate over all routes down the tree."

	| newLevel |
	workingConfigurationsSize = level ifTrue: ["we reached the leaves"
		workingConfigurations last do: [:conf | 
			currentRoute addLast: conf.
			aBlock value: currentRoute.
			currentRoute removeLast].
		^self].
	newLevel := level + 1.
	(workingConfigurations at: level) do: [:conf |
		currentRoute addLast: conf.
		self allRoutesDo: aBlock currentRoute: currentRoute level: newLevel.
		currentRoute removeLast]