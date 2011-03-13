addMorph: aMorph frame: relFrame
	| cc |
	cc _ aMorph color.
	super addMorph: aMorph frame: relFrame.
	aMorph color: cc.