collectCombinationsOfConfigurations
	"Given the wanted releases, find and return all possible combinations
	of working configurations for all those. Perhaps not possible to do
	given lots of releases and configurations, then we need smarter algorithms."
	
	"Pick out all working configurations first."
	workingConfigurations := (trickyReleases collect: [:r | r workingConfigurations]) asOrderedCollection.
	workingConfigurationsSize := workingConfigurations size.
	
	"We iterate over all possible combinations of configurations
	and collect the unique set of unordered configurations."
	combinations := Set new.
	self allRoutesDo: [:route |
		combinations add: route asSet copy] currentRoute: OrderedCollection new level: 1