replaceFrom: start to: stop with: replacement startingAt: repStart 
	"This destructively replaces elements from start to stop in the receiver starting at index, repStart, in replacementCollection. Do it to both the string and the runs."

	| rep newRepRuns |
	rep _ replacement asText.	"might be a string"
	string replaceFrom: start to: stop with: rep string startingAt: repStart.
	newRepRuns _ rep runs copyFrom: repStart to: repStart + stop - start.
	runs _ runs copyReplaceFrom: start to: stop with: newRepRuns