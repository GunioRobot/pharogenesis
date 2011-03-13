initializeShiftCmdKeyShortcuts
	"Initialize the shift-command-key (or control-key) shortcut table."

	| cmdMap cmds |
	"shift-command and control shortcuts"
	cmdMap _ Array new: 256.  "use temp in case of a crash"
	cmdMap atAllPut: #noop:.
	cmdMap at: ( 8 + 1) put: #backspace:.			"ctrl-H or delete key"
	cmdMap at: (27 + 1) put: #selectCurrentTypeIn:.	"escape key"

	"Note: Command key overrides shift key, so, for example, cmd-shift-9 produces $9 not $("
	'9[,''' do: [ :char | cmdMap at: (char asciiValue + 1) put: #shiftEnclose: ].	"({< and double-quote"
	cmdMap at: (27 + 1) put: #shiftEnclose:.	"ctrl-["
	"Note: Must use cmd-9 or ctrl-9 to get '()' since cmd-shift-9 is a Mac FKey command."

	cmds _ #(
		$a	argAdvance:
		$b	browseItHere:
		$c	compareToClipboard:
		$d	duplicate:
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