installPackageReleases: packageReleases
	"Given a Set of wanted SMPackageReleases, calculate all possible
	installation scenarios. If the analysis succeeds, return true, otherwise false."
	
	| result subAnalysis |
	wantedReleases := packageReleases copy.
	"First classify the releases in different groups."
	self partitionReleases.
	
	"If there are no tricky releases, we are already done.
	No extra required releases needs to be installed or upgraded."
	trickyReleases isEmpty ifTrue: [^success := true].

	"Ok, that was the easy part. The releases left now needs to be processed
	so that we can find out the different scenarios of required releases that we need
	to install first. First we calculate all combinations of available working configurations
	for the tricky releases."
	self collectCombinationsOfConfigurations.
	
	"Based on all configuration combinations,
	compute possible combinations of dependency releases."
	self computeInstallSets.
	
	"Check if we have failed - meaning that there are no valid scenarios without conflicts."
	suggestedInstallSetsSet isEmpty ifTrue: [^success := false].
	
	"Ok, this means we have at least one solution *on this level*! But we need to do the
	analysis recursively for all these sets of required releases..."
	subAnalysises := OrderedCollection new.
	success := false.
	suggestedInstallSetsSet do: [:set |
		subAnalysis := SMDependencyAnalysis task: task.
		result := subAnalysis installPackageReleases: set.
		result ifTrue: [success := true].
		subAnalysises add: subAnalysis].
	
	"Did at least one succeed? If so, then we have at least one possible scenario!
	If not, then we need to do tweaking."
	^success