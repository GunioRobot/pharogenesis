calculate
	"First calculate the wanted releases. Then perform a dependency analysis.
	We return the most basic result of the analysis - does there exist at least one
	working installation scenario without tweaks?"

	self calculateWantedReleases.
	analysis := SMDependencyAnalysis task: self.
	analysis installPackageReleases: wantedReleases.
	^analysis success