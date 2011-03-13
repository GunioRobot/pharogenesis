betadevUniverse
	"a combination of normal plus beta packages"
	"[UUniverse switchSystemToUniverse: UUniverse betadevUniverse]"
	^UCompoundUniverse composedOf: {
		self developmentUniverse.
		self betaUniverse
	}