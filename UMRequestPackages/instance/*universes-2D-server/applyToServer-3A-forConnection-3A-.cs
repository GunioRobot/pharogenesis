applyToServer: server forConnection: connection
	connection nextPut: (UMPackageList packages: server universe packages) asStringArray
