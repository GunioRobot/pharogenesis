xDuplicateTop

	"	-4	PopStack	_	MacroPopDup
		-0	nil"
	self rewrite: -4 from: PopStack to: MacroPopDup.

	self emitOp: DuplicateTop; emitSkip: 1.