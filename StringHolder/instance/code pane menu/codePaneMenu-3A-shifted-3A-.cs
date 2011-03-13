codePaneMenu: aMenu shifted: shifted
	"Note that unless we override doMenuItem:, PluggableTextController will respond to all menu items in a text pane"

| shiftMenu |
^ shifted 
	ifFalse: [aMenu 
		labels: PluggableTextController yellowButtonMenu labelString 
		lines: PluggableTextController yellowButtonMenu lineArray
		selections: PluggableTextController yellowButtonMessages]

	ifTrue: [shiftMenu _ PluggableTextController shiftedYellowButtonMenu.
		aMenu 
			labels: shiftMenu labelString 
			lines: shiftMenu lineArray
			selections: PluggableTextController shiftedYellowButtonMessages]
