contents
	| ans |
	currentRun > 0 ifTrue:[
		attributeValues nextPut: currentAttributes.
		attributeRuns nextPut: currentRun.
		currentRun := 0].
	ans := Text new: characters size.
	"this is declared private, but it's exactly what I need, and it's declared as exactly what I want it to do...."
	ans setString: characters contents  setRuns: 
		(RunArray runs: attributeRuns contents values: attributeValues contents).
	^ans