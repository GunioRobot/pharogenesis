setBoundsOfPaneMorphs
	| panelRect |
	panelRect _ self panelRect.
	paneMorphs with: paneRects do:
		[:m :frame |  "m color: paneColor."
		m bounds: (((frame scaleBy: panelRect extent) translateBy: panelRect topLeft)) truncated]