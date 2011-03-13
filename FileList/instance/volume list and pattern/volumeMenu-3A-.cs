volumeMenu: aMenu
	^ aMenu
		labels:
'fill in server info...
open server...
local disk'
		lines: # ()
		selections: #(askServerInfo openServer showLocalDir)
