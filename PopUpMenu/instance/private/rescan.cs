rescan
	"Cause my form to be recomputed after a font change."

	labelString == nil ifTrue: [labelString _ 'NoText!'].
	self labels: labelString font: (MenuStyle fontAt: 1) lines: lineArray.
	form _ nil.

	"PopUpMenu withAllSubclasses do: [ :menuClass |
		menuClass allInstancesDo: [ :m | m rescan ]]"