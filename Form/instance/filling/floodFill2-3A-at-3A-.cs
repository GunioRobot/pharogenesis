floodFill2: aColor at: interiorPoint
	"Fill the shape (4-connected) at interiorPoint.  The algorithm is based on Paul Heckbert's 'A Seed Fill Algorithm', Graphic Gems I, Academic Press, 1990.
	NOTE: This is a less optimized variant for flood filling which is precisely along the lines of Heckbert's algorithm. For almost all cases #floodFill:at: will be faster (see the comment there) but this method is left in both as reference and as a fallback if such a strange case is encountered in reality."
	| peeker poker stack old new x y top x1 x2 dy left goRight |
	peeker _ BitBlt current bitPeekerFromForm: self.
	poker _ BitBlt current bitPokerToForm: self.
	stack _ OrderedCollection new: 50.
	"read old pixel value"
	old _ peeker pixelAt: interiorPoint.
	"compute new value"
	new _ self pixelValueFor: aColor.
	old = new ifTrue:[^self]. "no point, is there?!"

	x _ interiorPoint x.
	y _ interiorPoint y.
	(y >= 0 and:[y < height]) ifTrue:[
		stack addLast: {y. x. x. 1}. "y, left, right, dy"
		stack addLast: {y+1. x. x. -1}].
	[stack isEmpty] whileFalse:[
		top _ stack removeLast.
		y _ top at: 1. x1 _ top at: 2. x2 _ top at: 3. dy _ top at: 4.
		y _ y + dy.
		"Segment of scanline (y-dy) for x1 <= x <= x2 was previously filled.
		Now explore adjacent pixels in scanline y."
		x _ x1.
		[x >= 0 and:[(peeker pixelAt: x@y) = old]] whileTrue:[
			poker pixelAt: x@y put: new.
			x _ x - 1].
		goRight _ x < x1.
		left _ x+1.
		(left < x1 and:[y-dy >= 0 and:[y-dy < height]]) 
			ifTrue:[stack addLast: {y. left. x1-1. 0-dy}].
		goRight ifTrue:[x _ x1 + 1].
		[
			goRight ifTrue:[
				[x < width and:[(peeker pixelAt: x@y) = old]] whileTrue:[
					poker pixelAt: x@y put: new.
					x _ x + 1].
				(y+dy >= 0 and:[y+dy < height]) 
					ifTrue:[stack addLast: {y. left. x-1. dy}].
				(x > (x2+1) and:[y-dy >= 0 and:[y-dy >= 0]]) 
					ifTrue:[stack addLast: {y. x2+1. x-1. 0-dy}]].
			[(x _ x + 1) <= x2 and:[(peeker pixelAt: x@y) ~= old]] whileTrue.
			left _ x.
			goRight _ true.
		x <= x2] whileTrue.
	].