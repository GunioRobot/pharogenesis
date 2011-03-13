wsmReleasesFor: packageId

	| html autoVersion version releases |
		
	releases := Dictionary new.
	
	html := self httpGet: (self wsm, '/package/', packageId ).
	
	[
		releases at: #latest put: autoVersion.
		autoVersion := html upToAll: '/autoversion/'; upTo: $".
		version := html upTo: $-; upTo: $<.
		
		(autoVersion notEmpty and: [version notEmpty ]) 

	] whileTrue: [ releases at: version put: autoVersion ].

	^ releases
	