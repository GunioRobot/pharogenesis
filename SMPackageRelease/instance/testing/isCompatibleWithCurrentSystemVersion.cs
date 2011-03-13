isCompatibleWithCurrentSystemVersion
	"Return true if this release is listed as being compatible with the SystemVersion of the current image.  Only checks major/minor version number; does not differentiate between alpha/beta/gamma releases.  Checks version categories of both the SMPackageRelease and the parent SMPackage."

	| current |
	current := self majorMinorVersionFrom: SystemVersion current version.
	self categories, self package categories do: [:c |
		((c parent name = 'Squeak versions') and: [
			(self majorMinorVersionFrom: c name) = current])
				ifTrue: [^true]].
	^ false
		
"	^ (self categories, self package categories
		detect:
			[:cat | (cat parent name = 'Squeak versions')
					and: [(SystemVersion new version: cat name) majorMinorVersion = SystemVersion current majorMinorVersion]]
		ifNone: []) notNil
"