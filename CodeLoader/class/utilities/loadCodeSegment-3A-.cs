loadCodeSegment: segmentName
	| loader |
	loader _ self new.
	loader loadSegments: (Array with: segmentName). 
	loader installSegments.