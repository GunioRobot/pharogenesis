url
	^FileUrl new path: (self directory pathParts), {self localFilename}
		isAbsolute: true