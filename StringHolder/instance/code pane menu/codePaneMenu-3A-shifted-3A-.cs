codePaneMenu: aMenu shifted: shifted
	"Note that unless we override perform:orSendTo:, PluggableTextController will respond to all menu items in a text pane"
	| donorMenu |
	donorMenu _ shifted
		ifTrue:
			[ParagraphEditor shiftedYellowButtonMenu]
		ifFalse:
			[ParagraphEditor yellowButtonMenu].
	^ aMenu labels: donorMenu labelString lines: donorMenu lineArray selections: donorMenu selections