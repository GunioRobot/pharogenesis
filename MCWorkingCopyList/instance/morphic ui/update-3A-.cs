update: aSymbol
	self workingCopies do: [:ea | ea addDependent: self].
	self changed: #workingCopyList.