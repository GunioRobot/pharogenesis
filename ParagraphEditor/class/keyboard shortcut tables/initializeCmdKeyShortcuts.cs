initializeCmdKeyShortcuts
	"Initialize the (unshifted) command-key shortcut table."
	"ParagraphEditor initialize"

	| cmdMap cmds |
	cmdMap _ Array new: 256.  "use temp in case of a crash"
	cmdMap atAllPut: #noop:.
	cmdMap at: ( 8 + 1) put: #backspace:.			"ctrl-H or delete key"
	cmdMap at: (27 + 1) put: #selectCurrentTypeIn:.	"escape key"

	'0123456789'	do: [ :char | cmdMap at: (char asciiValue + 1) put: #changeEmphasis: ].
	'([{''"<'		do: [ :char | cmdMap at: (char asciiValue + 1) put: #enclose: ].
	cmdMap at: ($, asciiValue + 1) put: #shiftEnclose:.

	cmds _ #(
		$a	selectAll:
		$b	browseIt:
		$c	copySelection:
		$d	doIt:
		$e	exchange:
		$f	find:
		$g	findAgain:
		$h	setSearchString:
		$i	inspectIt:
		$j	doAgainOnce:
		$k  offerFontMenu:
		$l	cancel:
		$m	implementorsOfIt:
		$n	sendersOfIt:
		$o	spawnIt:
		$p	printIt:
		$q	querySymbol:
		$r	recognizer:
		$s	save:
		$t	tempCommand:
		$u	align:
		$v	paste:
		$w	backWord:
		$x	cut:
		$y	swapChars:
		$z	undo:
	).
	1 to: cmds size by: 2 do: [ :i |
		cmdMap at: ((cmds at: i) asciiValue + 1) put: (cmds at: i + 1).
	].
	CmdActions _ cmdMap.
