ancestorSnapshot
	^ ancestorSnapshot ifNil: [ancestorSnapshot _ version workingCopy findSnapshotWithVersionInfo: self ancestorInfo]