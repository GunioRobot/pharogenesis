string: str for: morph corner: cornerName
	"Make up and return a balloon for morph.  Find the quadrant that
clips the text the least, using cornerName as a tie-breaker.  tk 9/12/97"

	| tm corners p1 p2 vertices c r maxArea aa verts mp dir mbc
 pref |
	
	tm _ (TextMorph new contents: (self textContentsForString: str)) centered.
	corners _ tm bounds corners atAll: #(1 4 3 2).
	p1 _ (corners at: 1) + ((0 - tm width//3)@0).
	p2 _ (corners at: 1) + ((0 - tm width//6)@(tm height//2)).
	vertices _ (Array with: p1 with: p2) , corners.
	r _ p1 rect: (corners at: 3).
	corners _ #(bottomRight bottomLeft topLeft topRight).
	pref _ (corners indexOf: cornerName)-4.
	c _ tm center.
	maxArea _ 0.
	(1 to: 4) do:
		[:i | "Try four rel locations of the balloon for greatest unclipped area"
		aa _ ((r align: (r perform: (corners atWrap: i+pref+2))
			with: (mbc _ morph bounds perform: (corners atWrap: i+pref)))
			intersect: (0@0 extent: morph world viewBox extent)) area.
		aa >= maxArea ifTrue: [verts _ vertices.
							maxArea _ aa.
							mp _ mbc].
		dir _ i odd ifTrue: [#horizontal] ifFalse: [#vertical].
		vertices _ vertices collect: [:p | p flipBy: dir centerAt: c]].
	self removeCurrentBalloon.
	^ CurrentBalloon _ self new color: (Color r: 1.0 g: 1.0 b: 0.6);
			setBorderWidth: 1 borderColor: Color black;
			setVertices: verts;
			addMorph: tm;
			align: verts first with: mp;
			setTarget: morph