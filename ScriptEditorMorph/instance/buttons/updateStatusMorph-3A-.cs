updateStatusMorph: statusMorph
	"my status button may need to reflect an externally-induced change in status"
	|  statusSymbol colorSelector |
	statusMorph ifNil: [^ self].
	statusSymbol _ self scriptInstantiation status.
	colorSelector _ ScriptingSystem statusColorSymbolFor: statusSymbol.
	statusMorph recolor: (Color perform: colorSelector) muchLighter.
	statusMorph label: statusSymbol asString font: Preferences standardButtonFont