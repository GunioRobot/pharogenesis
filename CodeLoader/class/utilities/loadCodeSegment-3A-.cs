loadCodeSegment: segmentName
	| loader |
	loader _ PluginCodeLoader new.
	loader loadSegments: (Array with: segmentName). 
	loader installSegments.