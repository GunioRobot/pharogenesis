selectedPackage
	^ self selectedDependency ifNotNilDo: [:dep | dep package]