computeInstallSets
	"Given all combinations of configurations, compute all valid combinations
	of depdendency releases - all possible different Sets of required releases
	to install before the trickyReleases can be installed."
	
	"For each unique combination of configurations, collect all required releases
	and produce a Set of unique required release combinations." 
	suggestedInstallSetsSet := (combinations collect: [:comb |
								comb inject: Set new into: [:set :conf |
									set addAll: conf requiredReleases.
									set ]]) asSet.

	"Filter out those Sets that have multiple releases of the same package, they are conflicting
	and thus not valid - we can't have two different releases of the same package
	installed at the same time."
	
	"conflictingInstallSetsSet := suggestedInstallSetsSet select:
								[:set | self detectConflictingReleasesIn: set].
	suggestedInstallSetsSet removeAll: conflictingInstallSetsSet"