otherReleases
	| package |
	package := selectedRelease package.
	^ brokenConfigurations collect: [:conf |
		conf releases detect: [:r | r package == package]]