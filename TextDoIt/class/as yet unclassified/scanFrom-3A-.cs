scanFrom: strm
	"read a doit in the funny format used by Text styles on files. d10 factorial;;  end with two semicolons"

	| pos end doit |
	pos _ strm position.
	[strm skipTo: $;. strm peek == $;] whileFalse.
	end _ strm position - 1.
	strm position: pos.
	doit _ strm next: end-pos.
	strm skip: 2.  ";;"
	^ self evalString: doit