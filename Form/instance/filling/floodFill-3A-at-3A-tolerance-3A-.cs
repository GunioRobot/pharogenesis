floodFill: aColor at: interiorPoint tolerance: tolerance
	"Fill the shape (4-connected) at interiorPoint.  The algorithm is based on Paul Heckbert's 'A Seed Fill Algorithm', Graphic Gems I, Academic Press, 1990.
	NOTE (ar): This variant has been heavily optimized to prevent the overhead of repeated calls to BitBlt. Usually this is a really big winner but the runtime now depends a bit on the complexity of the shape to be filled. For extremely complex shapes (say, a Hilbert curve) with very few pixels to fill it can be slower than #floodFill2:at: since it needs to repeatedly read the source bits. However, in all practical cases I found this variant to be 15-20 times faster than anything else.
	Further note (di):  I have added a feature that allows this routine to fill areas of approximately constant color (such as  photos, scans, and jpegs).  It does this by computing a color map for the peeker that maps all colors close to 'old' into colors identical to old.  This mild colorblindness achieves the desired effect with no further change or degradation of the algorithm.  tolerance should be 0 (exact match), or a value corresponding to those returned by Color>>diff:, with 0.1 being a reasonable starting choice."

	| peeker poker stack old new x y top x1 x2 dy left goRight span spanBits w box debug |
	debug _ false. "set it to true to see the filling process"
	box _ interiorPoint extent: 1@1.
	span _ Form extent: width@1 depth: 32.
	spanBits _ span bits.

	peeker _ BitBlt current toForm: span.
	peeker 
		sourceForm: self; 
		combinationRule: 3; 
		width: width; 
		height: 1.

	"read old pixel value"
	peeker sourceOrigin: interiorPoint; destOrigin: interiorPoint x @ 0; width: 1; copyBits.
	old _ spanBits at: interiorPoint x + 1.

	"compute new value (take care since the algorithm will fail if old = new)"
	new _ self privateFloodFillValue: aColor.
	old = new ifTrue: [^ box].
	tolerance > 0 ifTrue:
		["Set up color map for approximate fills"
		peeker colorMap: (self floodFillMapFrom: self to: span mappingColorsWithin: tolerance to: old)].

	poker _ BitBlt current toForm: self.
	poker 
		fillColor: aColor;
		combinationRule: 3;
		width: width;
		height: 1.

	stack _ OrderedCollection new: 50.
	x _ interiorPoint x.
	y _ interiorPoint y.
	(y >= 0 and:[y < height]) ifTrue:[
		stack addLast: {y. x. x. 1}. "y, left, right, dy"
		stack addLast: {y+1. x. x. -1}].

	[stack isEmpty] whileFalse:[
		debug ifTrue:[self displayOn: Display].
		top _ stack removeLast.
		y _ top at: 1. x1 _ top at: 2. x2 _ top at: 3. dy _ top at: 4.
		y _ y + dy.
		debug ifTrue:[
			(Line from: (x1-1)@y to: (x2+1)@y 
				withForm: (Form extent: 1@1 depth: 8) fillWhite) displayOn: Display].
		"Segment of scanline (y-dy) for x1 <= x <= x2 was previously filled.
		Now explore adjacent pixels in scanline y."
		peeker sourceOrigin: 0@y; destOrigin: 0@0; width: width; copyBits.
			"Note: above is necessary since we don't know where we'll end up filling"
		x _ x1.
		w _ 0.
		[x >= 0 and:[(spanBits at: x+1) = old]] whileTrue:[
			w _ w + 1.
			x _ x - 1].
		w > 0 ifTrue:[
			"overwrite pixels"
			poker destOrigin: x+1@y; width: w; copyBits.
			box _ box quickMerge: ((x+1@y) extent: w@1)].
		goRight _ x < x1.
		left _ x+1.
		(left < x1 and:[y-dy >= 0 and:[y-dy < height]]) 
			ifTrue:[stack addLast: {y. left. x1-1. 0-dy}].
		goRight ifTrue:[x _ x1 + 1].
		[
			goRight ifTrue:[
				w _ 0.
				[x < width and:[(spanBits at: x+1) = old]] whileTrue:[
					w _ w + 1.
					x _ x + 1].
				w > 0 ifTrue:[
					"overwrite pixels"
					poker destOrigin: (x-w)@y; width: w; copyBits.
					box _ box quickMerge: ((x-w@y) extent: w@1)].
				(y+dy >= 0 and:[y+dy < height]) 
					ifTrue:[stack addLast: {y. left. x-1. dy}].
				(x > (x2+1) and:[y-dy >= 0 and:[y-dy >= 0]]) 
					ifTrue:[stack addLast: {y. x2+1. x-1. 0-dy}]].
			[(x _ x + 1) <= x2 and:[(spanBits at: x+1) ~= old]] whileTrue.
			left _ x.
			goRight _ true.
		x <= x2] whileTrue.
	].
	^box