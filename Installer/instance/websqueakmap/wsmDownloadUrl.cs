wsmDownloadUrl 

| pkgAndVersion packageId packageName packageVersion releaseAutoVersion
 downloadPage |

	pkgAndVersion := self smPackageAndVersion.
	packageName := pkgAndVersion first.
	packageVersion := pkgAndVersion last.
	packageVersion isEmpty ifTrue: [ packageVersion := #latest ].

	packageId := self wsmPackagesByName at: packageName.
	releaseAutoVersion := (self wsmReleasesFor: packageId) at: packageVersion.
					 
	downloadPage := self httpGet: (self wsm,'packagebyname/', packageName,'/autoversion/', releaseAutoVersion,'/downloadurl') asUrl asString.
				 		 
	^ downloadPage contents
	
