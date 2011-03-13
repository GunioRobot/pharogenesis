relativeUrl
	"Return the relative url for this release on an SM server."
	
	^'package/', package id asString, '/autoversion/', automaticVersion versionString