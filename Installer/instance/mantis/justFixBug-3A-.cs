justFixBug: aBugNo

	^self class skipLoadingTests: true during: [ self fixBug: aBugNo date: nil ]