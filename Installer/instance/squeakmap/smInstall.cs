smInstall 

	| pkgAndVersion releases release |

	pkgAndVersion := self smPackageAndVersion.

	self logCR: 'installing ', self package, ' from SqueakMap...'.


	releases := self smReleasesForPackage: pkgAndVersion first.
 	
	release := pkgAndVersion last isEmpty ifTrue: [ releases last ]
					ifFalse:[ releases detect: [ :rel | rel version = pkgAndVersion last ] ]. 
	
	self withAnswersDo: [ release install ].

	self log: ' done'.
