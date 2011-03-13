wsmVersions

| pkgAndVersion packageId packageName packageVersion versions |

	pkgAndVersion := self smPackageAndVersion.
	packageName := pkgAndVersion first.
	packageVersion := pkgAndVersion last.
	packageVersion isEmpty ifTrue: [ packageVersion := #latest ].

	packageId := self wsmPackagesByName at: packageName.
	
	versions := (self wsmReleasesFor: packageId) keys.
	versions remove: #latest.
	
	^ versions collect: [ :version | self copy package: (packageName,'(', version ,')'); yourself ]. 