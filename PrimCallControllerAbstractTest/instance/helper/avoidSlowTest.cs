avoidSlowTest

	^ doNotMakeSlowTestsFlag and: [pcc class = PCCByCompilation]