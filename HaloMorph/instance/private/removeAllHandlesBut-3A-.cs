removeAllHandlesBut: h
	"Remove all handles except h."
	submorphs copy do:
		[:m | m == h ifFalse: [m delete]].
