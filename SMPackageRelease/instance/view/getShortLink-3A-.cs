getShortLink: aBuilder

	^aBuilder
		getLinkLocal: '/package/', self package id asString, '/autoversion/',
					self automaticVersion versionString
		text: self listName