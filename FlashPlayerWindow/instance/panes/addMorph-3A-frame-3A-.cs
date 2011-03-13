addMorph: aMorph frame: relFrame
	"Do not change the color"
	| cc |
	cc := aMorph color.
	super addMorph: aMorph frame: relFrame.
	aMorph color: cc.