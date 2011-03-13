fileNameFormattedFrom: entry sizePad: sizePad sortMode: sortMode
	"Parse one ftp directory entry
d---------   1 owner    group               0 Apr 27 22:01 blasttest
----------   1 owner    group           93812 Jul 21  1997 COMMAND.COM
"

	^ (entry at: 1) == $d 
		ifTrue: [(entry findTokens: ' ') last , self folderString, '    ()']
		ifFalse: [(entry findTokens: ' ') last , '    ()']	"get fancier later"