buildPatchSequence
	"@@ TODO: Das funktioniert noch nicht für n-m matches"
	matches := PluggableDictionary new.
	matches hashBlock: self pointHashBlock.
	self buildReferenceMap.
	runs := self processDiagonals.
	self validateRuns: runs.
	"There may be things which have just been moved around. Find those."
	shifted := self detectShiftedRuns.
	self processShiftedRuns.
	"Now generate a patch sequence"
	patchSequence := self generatePatchSequence.
	^patchSequence