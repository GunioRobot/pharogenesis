clearRequiredPackages
	workingCopy ifNotNilDo:
		[:wc |
		wc clearRequiredPackages.
		self changed: #workingCopyList]