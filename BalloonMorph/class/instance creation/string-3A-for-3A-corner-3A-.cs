string: str for: morph corner: cornerName
	"Make up and return a balloon for morph.  Find the quadrant that
	clips the text the least, using cornerName as a tie-breaker.  tk 9/12/97"

	| tm vertices |
	tm _ self getTextMorph: str.
	vertices _ self getVertices: tm bounds.
	vertices _ self getBestLocation: vertices for: morph corner: cornerName.
	^ self new
		color: morph balloonColor;
		setVertices: vertices;
		addMorph: tm;
		setTarget: morph