currentAttributes: newAttributes
	"set the current attributes"
	(currentRun > 0 and:[currentAttributes ~= newAttributes]) ifTrue:[
		attributeRuns nextPut: currentRun.
		attributeValues nextPut: currentAttributes.
		currentRun _ 0.
	].
	currentAttributes _ newAttributes.
