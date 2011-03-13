isGray
	"Find least squared distance of r, g, b from one another. 6/18/96 tk"

	| rr gg bb diff |
	rr _ self privateRed.  gg _ self privateGreen.  bb _ self privateBlue.
	diff _ ((rr-gg)*(rr-gg)) + ((gg-bb)*(gg-bb)) + ((bb-rr)*(bb-rr)). 		"least squares"
	"If diff is big, r g and b not very close, not very much like a gray.  One 6x6x6 step is 1023.0 / 5.0 = 204.6.  Squared is 204.6 * 204.6 =  41861.2
If closer than that, its more a gray than a color." 
	^ diff < 41861