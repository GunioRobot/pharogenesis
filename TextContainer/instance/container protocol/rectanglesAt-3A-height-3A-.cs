rectanglesAt: lineY height: lineHeight
	"Return a list of rectangles that are at least minWidth wide
	in the specified horizontal strip of the shadowForm.
	Cache the results for later retrieval if the owner does not change."
	| hProfile rects thisWidth thisX count pair outerWidth lineRect lineForm |
	pair _ Array with: lineY with: lineHeight.
	rects _ rectangleCache at: pair ifAbsent: [nil].
	rects ifNotNil: [^ rects].

	outerWidth _ minWidth + (2*OuterMargin).
	self shadowForm.  "Compute the shape".
	lineRect _ 0@(lineY - shadowForm offset y)
					extent: shadowForm width@lineHeight.
	lineForm _ shadowForm copy: lineRect.

	"Check for a full line -- frequent case"
	(lineForm tallyPixelValues at: 2) = lineRect area
	ifTrue:
		[rects _ Array with: (shadowForm offset x@lineY extent: lineRect extent)]
	ifFalse:
		["No such luck -- scan the horizontal profile for segments of minWidth"
		hProfile _ lineForm xTallyPixelValue: 1 orNot: false.
		rects _ OrderedCollection new.
		thisWidth _ 0.  thisX _ 0.
		1 to: hProfile size do:
			[:i | count _ hProfile at: i.
			count >= lineHeight ifTrue:
				[thisWidth _ thisWidth + 1]
				ifFalse:
				[thisWidth >= outerWidth ifTrue:
					[rects addLast: ((thisX + shadowForm offset x)@lineY
									extent: thisWidth@lineHeight)].
				thisWidth _ 0. thisX _ i]].
		thisWidth >= outerWidth ifTrue:
				[rects addLast: ((thisX + shadowForm offset x)@lineY
									extent: thisWidth@lineHeight)]].
	rects _ rects collect: [:r | r insetBy: OuterMargin@0].
	rectangleCache at: pair put: rects.
	^ rects