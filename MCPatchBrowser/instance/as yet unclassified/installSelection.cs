installSelection
	| loader |
	selection ifNotNil:
		[loader _ MCPackageLoader new.
		selection applyTo: loader.
		loader loadWithName: self changeSetNameForInstall ]