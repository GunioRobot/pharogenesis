initializeShiftCmdKeyShortcuts
	"Initialize the shift-command-key (or control-key) shortcut table."
	"NOTE: if you don't know what your keyboard generates, use Sensor kbdTest"

	| cmdMap cmds |
	"shift-command and control shortcuts"
	cmdMap _ Array new: 256.  "use temp in case of a crash"
	cmdMap atAllPut: #noop:.
	cmdMap at: ( 1 + 1) put: #cursorHome:.			"home key"
	cmdMap at: ( 4 + 1) put: #cursorEnd:.			"end key"
	cmdMap at: ( 8 + 1) put: #forwardDelete:.			"ctrl-H or delete key"
	cmdMap at: (13 + 1) put: #crWithIndent:.			"ctrl-Return"
	cmdMap at: (27 + 1) put: #selectCurrentTypeIn:.	"escape key"
	cmdMap at: (28 + 1) put: #cursorLeft:.			"left arrow key"
	cmdMap at: (29 + 1) put: #cursorRight:.			"right arrow key"
	cmdMap at: (30 + 1) put: #cursorUp:.				"up arrow key"
	cmdMap at: (31 + 1) put: #cursorDown:.			"down arrow key"
	cmdMap at: (45 + 1) put: #changeEmphasis:.		"cmd-sh-minus"
	cmdMap at: (61 + 1) put: #changeEmphasis:.		"cmd-sh-plus"
	cmdMap at: (127 + 1) put: #forwardDelete:.		"del key"

	"Note: Command key overrides shift key, so, for example, cmd-shift-9 produces $9 not $("
	'9[,''' do: [ :char | cmdMap at: (char asciiValue + 1) put: #shiftEnclose: ].	"({< and double-quote"
	"Note: Must use cmd-9 or ctrl-9 to get '()' since cmd-shift-9 is a Mac FKey command."
	cmdMap at: (27 + 1) put: #shiftEnclose:.	"ctrl-["

	cmds _ #(
		$a	argAdvance:
		$b	browseItHere:
		$c	compareToClipboard:
		$d	duplicate:
		$e	methodStringsContainingIt:
		$f	displayIfFalse:
		$j	doAgainMany:
		$k	changeStyle:
		$n	referencesToIt:
		$r	indent:
		$l	outdent:
		$s	search:
		$t	displayIfTrue:
		$w	methodNamesContainingIt:
		$v	pasteInitials:
	).
	1 to: cmds size by: 2 do: [ :i |
		cmdMap at: ((cmds at: i) asciiValue + 1)			put: (cmds at: i + 1).
		cmdMap at: (((cmds at: i) asciiValue - 96) + 1)	put: (cmds at: i + 1).
	].
	ShiftCmdActions _ cmdMap.