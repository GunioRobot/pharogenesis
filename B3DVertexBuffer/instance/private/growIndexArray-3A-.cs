growIndexArray: newSize
	| newIdxArray |
	newIdxArray _ indexArray species new: newSize.
	newIdxArray replaceFrom: 1 to: indexArray size with: indexArray startingAt: 1.
	indexArray _ newIdxArray.