includesClassNamed: aClassName
	^ self includesSystemCategory: ((SystemOrganization categoryOfElement: aClassName) ifNil: [^false])