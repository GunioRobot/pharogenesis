updateStatusMorph: statusControlMorph
	"the status control may need to reflect an externally-induced change in status"

	|  statusSymbol colorSelector statusReadoutButton |

	statusControlMorph ifNil: [^ self].
	statusSymbol _ self status.

	(#(paused ticking) includes: statusSymbol)
		ifTrue:
			[statusControlMorph assurePauseTickControlsShow]
		ifFalse:
			[statusControlMorph maybeRemovePauseTickControls].
	statusReadoutButton _ statusControlMorph submorphs last.
	colorSelector _ ScriptingSystem statusColorSymbolFor: statusSymbol.
	statusReadoutButton color: (Color perform: colorSelector) muchLighter.
	statusReadoutButton label: statusSymbol asString font: Preferences standardButtonFont