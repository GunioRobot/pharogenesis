selectedRelease: aRelease releases: releases

	| p others otherRequired |
	selectedRelease := aRelease.
	p := selectedRelease package.
	brokenConfigurations := OrderedCollection new.
	others := releases copyWithout: aRelease.
	others := others select: [:r | r package ~= p].
	others do: [:rel |
		rel workingConfigurations do: [:conf |
			otherRequired := conf requiredReleases select: [:r | r package ~= p].
			((others includesAllOf: otherRequired) and:
				[(conf requiredReleases includes: selectedRelease) not])
					ifTrue: [brokenConfigurations add: conf]]]