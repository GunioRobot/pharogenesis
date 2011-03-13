addPackage: aPackage
	"make sure that we end up with no two packages with the same name and version"
	packages removeAllSuchThat: [ :p | p name = aPackage name and: [ p version = aPackage version ] ].
	
	"now add the new package"
	packages add: aPackage.

	self changed: #packages