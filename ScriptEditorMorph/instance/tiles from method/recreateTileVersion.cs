recreateTileVersion
	"The receiver, currently showing textual code, is asked to create fresh tiles by decompiling the code of the textual script."

	| parseTree |

	true ifTrue: [^ self inform: 'No, this is really Under Construction!
Not yet available'].

	parseTree _ Decompiler new decompile: scriptName
		in: playerScripted class 
		method: (playerScripted class compiledMethodAt: scriptName).
	self tilesFrom: parseTree.

	self flag: #noteToTed.   "Ted, see my notes in #tilesFrom:"
	self install.