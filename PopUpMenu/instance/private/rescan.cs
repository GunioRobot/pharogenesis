rescan
	"Cause my form to be recomputed after a font change."

	labelString == nil ifTrue: [labelString _ 'NoText!'].
	self labels: labelString font: (MenuStyle fontAt: 1) lines: lineArray.
	frame _ marker _ form _ nil.

	"PopUpMenu allSubInstancesDo: [:m | m rescan]"