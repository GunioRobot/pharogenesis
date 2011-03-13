dependsString: aString 
	package depends: (self packageNamesFromString: aString).
	self changed: #dependsString