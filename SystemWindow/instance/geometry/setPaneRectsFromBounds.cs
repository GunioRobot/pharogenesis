setPaneRectsFromBounds
	"Reset proportional specs from actual bounds, eg, after reframing panes"
	| panelRect |
	panelRect _ self panelRect.
	paneRects _ paneMorphs collect:
		[:m | 
		(m bounds translateBy: panelRect topLeft negated)
			scaleBy: (1.0 asPoint / panelRect extent)]