menu: aMenu shifted: shiftState

	aMenu labels: 
'set host name
set port
connect
disconnect' lines: #() selections: #(setHostName setPort connect disconnect).
	^aMenu