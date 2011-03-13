addButtons

	| marginPt i sz data images pageNumber proj f m b1 b2 dot arrowWidth arrowCenter vertices arrowHeight allMorphicProjects nameMorph |

	allMorphicProjects _ Project allMorphicProjects.
	self changeNoLayout.
	self hResizing: #rigid. "... this is very unlikely..."
	self vResizing: #rigid.
	marginPt _ 4@4.
	i _ self currentIndex.
	sz _ 50@40.
	arrowWidth _ 14.
	arrowHeight _ 17.
	data _ {
		{i - 1. 'Previous:'. #previousPage. #rightCenter. arrowWidth negated}.
		{i + 1. 'Next:'. #nextPage. #leftCenter. arrowWidth}
	}.
	images _ data collect: [ :tuple |
		pageNumber _ tuple first.
		(pageNumber between: 1 and: listOfPages size) ifTrue: [
			proj _ Project named: (listOfPages at: pageNumber) first in: allMorphicProjects.
			f _ (self makeThumbnailFor: proj) scaledToSize: sz.
			arrowCenter _ f boundingBox perform: tuple fourth.
			vertices _ {
				arrowCenter - (0@arrowHeight).
				arrowCenter + (0@arrowHeight).
				arrowCenter + (tuple fifth @ 0).
			}.
			f getCanvas
				drawPolygon: vertices 
				color: Color orange 
				borderWidth: 0 
				borderColor: Color transparent.
			m _ ImageMorph new image: f.
			m setBalloonText: tuple second,' ',(listOfPages at: pageNumber) first.
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
	dot _ EllipseMorph new extent: 16@16; color: Color orange lighter; borderWidth: 0.
	self addMorph: (b1 position: self position + marginPt).
	self addMorph: (b2 position: b1 topRight + (marginPt x @ 0)).
	self extent: b2 bottomRight - self position + marginPt.
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
		height: 15;
		align: nameMorph bottomLeft with: self bottomLeft.

