addButtons

	| marginPt i sz data images pageNumber f m b1 b2 dot arrowWidth arrowCenter vertices arrowHeight nameMorph sizeRatio controlsColor |

	sizeRatio _ self sizeRatio.
	controlsColor _ Color orange lighter.

	self changeNoLayout.
	self hResizing: #rigid.
	self vResizing: #rigid.
	marginPt _ (4 @ 4 * sizeRatio) rounded..
	i _ self currentIndex.
	sz _ self myThumbnailSize.
	arrowWidth _ (14 * sizeRatio) rounded.
	arrowHeight _ (14 * sizeRatio) rounded.
	data _ {
		{i - 1. 'Previous:'. #previousPage. #leftCenter. arrowWidth. 'Prev'}.
		{i + 1. 'Next:'. #nextPage. #rightCenter. arrowWidth negated. 'Next'}
	}.
	images _ data collect: [ :tuple |
		pageNumber _ tuple first.
		(pageNumber between: 1 and: listOfPages size) ifTrue: [
			f _ self 
				makeThumbnailForPageNumber: pageNumber 
				scaledToSize: sz 
				default: tuple sixth.
			f _ f deepCopy.		"we're going to mess it up"
			arrowCenter _ f boundingBox perform: tuple fourth.
			vertices _ {
				arrowCenter + (tuple fifth @ arrowHeight negated).
				arrowCenter + (tuple fifth @ arrowHeight).
				arrowCenter.
			}.
			f getCanvas
				drawPolygon: vertices 
				color: controlsColor
				borderWidth: 0 
				borderColor: Color transparent.
			m _ ImageMorph new image: f.
			m setBalloonText: tuple second translated,' ',(listOfPages at: pageNumber) first.
			m addMouseUpActionWith: (
				MessageSend receiver: self selector: tuple third
			).
		] ifFalse: [
			f _ (Form extent: sz depth: 16) fillColor: Color lightGray.
			m _ ImageMorph new image: f.
		].
		m
	].
	b1 _ images first.
	b2 _ images second.
	dot _ EllipseMorph new extent: (18@18 * sizeRatio) rounded; color: controlsColor; borderWidth: 0.

	self addMorph: (b1 position: self position + marginPt).
	self addMorph: (b2 position: b1 topRight + (marginPt x @ 0)).

	self extent: (b1 bottomRight max: b2 bottomRight) - self position + marginPt.
	self addMorph: dot.
	dot align: dot center with: b1 bounds rightCenter + ((marginPt x @ 0) // 2).
	dot setBalloonText: threadName,'
more commands'.
	dot on: #mouseDown send: #moreCommands to: self.
	self fullBounds.
	self addMorph: (nameMorph _ SquishedNameMorph new).
	nameMorph
		target: self getSelector: #threadName setSelector: nil;
		color: Color transparent;
		width: self width;
		height: (15 * sizeRatio) rounded;
		align: nameMorph bottomLeft with: self bottomLeft.

