haloSpecifications
	"Answer a list of HaloSpecs that describe which halos are to be used, what they should look like, and where they should be situated"
	"Preferences resetHaloSpecifications"

	^ Parameters at: #HaloSpecs ifAbsent:
			[self installHaloTheme: #iconicHaloSpecifications]

	"Preferences haloSpecifications"